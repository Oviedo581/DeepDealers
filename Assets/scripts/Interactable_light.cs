using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Light[] lights;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnInteract()
    {
        // Apagar todas las luces
        foreach (Light light in lights)
        {
            light.enabled = !light.enabled; // Cambia el estado de encendido/apagado
        }

        // Reproducir sonido
        if (audioSource != null)
        {
            audioSource.Play();
        }

        Debug.Log("Interacted with " + gameObject.name);
    }
}