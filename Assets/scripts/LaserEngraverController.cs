using System.Collections;
using UnityEngine;

public class LaserEngraverController : MonoBehaviour
{
    public Animator laserEngraverAnimator; // Asignar el Animator del Laser Engraver
    public string engraveAnimationName = "Engraving"; // Nombre de la animación de grabado
    public AudioSource audioSource; // Referencia al AudioSource

    private bool isEngraving = false; // Estado de grabado

    void OnMouseDown()
    {
        if (!isEngraving)
        {
            StartCoroutine(StartEngraving());
        }
    }

    private IEnumerator StartEngraving()
    {
        isEngraving = true;
        laserEngraverAnimator.Play(engraveAnimationName);

        // Reproducir el sonido
        if (audioSource != null)
        {
            audioSource.Play();
        }

        // Espera la duración de la animación
        yield return new WaitForSeconds(laserEngraverAnimator.GetCurrentAnimatorStateInfo(0).length);

        isEngraving = false;
    }
}
