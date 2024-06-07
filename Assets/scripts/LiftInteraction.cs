using System.Collections;
using UnityEngine;

public class LiftInteraction : MonoBehaviour
{
    public GameObject handle;  // Referencia a la manija "Rosca"
    public GameObject door;    // Referencia a la tapa "Plano"
    public Vector3 liftAxis = Vector3.right; // Eje de rotación
    public float liftAngle = 90f; // Ángulo de rotación
    public float animationDuration = 1f; // Duración de la animación

    private Quaternion initialHandleRotation; // Rotación inicial de la manija
    private Quaternion targetHandleRotation; // Rotación final de la manija
    private Quaternion initialDoorRotation;  // Rotación inicial de la tapa
    private Quaternion targetDoorRotation;   // Rotación final de la tapa
    private bool isAnimating = false;        // Estado de animación
    private bool isOpen = false;             // Estado de la tapa (abierta o cerrada)

    void Start()
    {
        // Guardar las rotaciones iniciales
        initialHandleRotation = handle.transform.rotation;
        initialDoorRotation = door.transform.rotation;

        // Calcular las rotaciones finales
        targetHandleRotation = Quaternion.AngleAxis(liftAngle, liftAxis) * initialHandleRotation;
        targetDoorRotation = Quaternion.AngleAxis(liftAngle, liftAxis) * initialDoorRotation;
    }

    void OnMouseDown()
    {
        if (!isAnimating)
        {
            StartCoroutine(AnimateLift());
        }
    }

    private IEnumerator AnimateLift()
    {
        isAnimating = true;
        float elapsedTime = 0f;
        
        // Determinar las rotaciones objetivo basadas en el estado actual
        Quaternion startHandleRotation = isOpen ? targetHandleRotation : initialHandleRotation;
        Quaternion endHandleRotation = isOpen ? initialHandleRotation : targetHandleRotation;
        Quaternion startDoorRotation = isOpen ? targetDoorRotation : initialDoorRotation;
        Quaternion endDoorRotation = isOpen ? initialDoorRotation : targetDoorRotation;

        while (elapsedTime < animationDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / animationDuration);
            
            // Rotar la manija y la tapa
            handle.transform.rotation = Quaternion.Lerp(startHandleRotation, endHandleRotation, t);
            door.transform.rotation = Quaternion.Lerp(startDoorRotation, endDoorRotation, t);

            yield return null;
        }

        // Asegúrate de que las rotaciones finales se establezcan correctamente
        handle.transform.rotation = endHandleRotation;
        door.transform.rotation = endDoorRotation;

        isAnimating = false;
        isOpen = !isOpen; // Cambiar el estado de la tapa
    }
}
