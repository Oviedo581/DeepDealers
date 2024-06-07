using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 2.0f; // Velocidad de movimiento de la cámara
    public float mouseSensitivity = 2.0f; // Sensibilidad del ratón
    public float maxVerticalAngle = 90f; // Ángulo máximo de rotación vertical

    private float pitch = 0.0f; // Rotación en el eje X (vertical)
    private float yaw = 0.0f; // Rotación en el eje Y (horizontal)
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        // Oculta el cursor y lo bloquea en el centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Movimiento de la cámara con las teclas del teclado (sólo en el plano horizontal)
        float moveForwardBackward = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float moveLeftRight = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        // Calcula el vector de movimiento en el plano horizontal
        Vector3 move = transform.right * moveLeftRight + transform.forward * moveForwardBackward;
        move.y = 0; // Asegura que no haya movimiento vertical

        // Mueve el CharacterController
        characterController.Move(move);

        // Rotación de la cámara con el ratón
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Limitar la rotación vertical para evitar que la cámara se voltee completamente
        pitch = Mathf.Clamp(pitch, -maxVerticalAngle, maxVerticalAngle);

        // Aplicar la rotación a la cámara
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        // Mostrar el cursor y desbloquearlo cuando se presiona la tecla ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        // Ocultar el cursor y bloquearlo en el centro de la pantalla cuando se presiona la tecla "L"
        if (Input.GetKeyDown(KeyCode.L))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
