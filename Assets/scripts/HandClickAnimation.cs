using System.Collections;
using UnityEngine;

public class HandClickAnimation : MonoBehaviour
{
    public Transform handModel; // Referencia al modelo de la mano
    public Vector3 clickDownPosition = new Vector3(0.0f, -0.1f, 0.0f); // Posición de la mano al hacer clic
    public float clickDuration = 0.1f; // Duración de la animación de clic

    private Vector3 initialPosition; // Posición inicial de la mano

    void Start()
    {
        // Guardar la posición inicial de la mano
        initialPosition = handModel.localPosition;
    }

    void Update()
    {
        // Detectar el clic del mouse
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(ClickAnimation());
        }
    }

    private IEnumerator ClickAnimation()
    {
        // Mover la mano a la posición de clic
        handModel.localPosition = initialPosition + clickDownPosition;

        // Esperar la duración del clic
        yield return new WaitForSeconds(clickDuration);

        // Volver la mano a la posición inicial
        handModel.localPosition = initialPosition;
    }
}
