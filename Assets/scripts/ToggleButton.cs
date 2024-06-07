using UnityEngine;

public class ToggleButton : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip machineOnSound;
    public AudioClip machineOffSound;
    public GameObject chiller;  // Referencia al objeto Chiller
    private AudioSource chillerAudioSource;
    private bool isOn = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (chiller != null)
        {
            chillerAudioSource = chiller.GetComponent<AudioSource>();
        }
    }

    void OnMouseDown()
    {
        if (isOn)
        {
            // Reproducir sonido de apagado
            if (machineOffSound != null)
            {
                audioSource.clip = machineOffSound;
                audioSource.Play();
            }

            // Detener sonido del motor
            if (chillerAudioSource != null && chillerAudioSource.isPlaying)
            {
                chillerAudioSource.Stop();
            }
        }
        else
        {
            // Reproducir sonido de encendido
            if (machineOnSound != null)
            {
                audioSource.clip = machineOnSound;
                audioSource.Play();
            }

            // Iniciar sonido del motor
            if (chillerAudioSource != null && !chillerAudioSource.isPlaying)
            {
                chillerAudioSource.Play();
            }
        }

        // Cambiar el estado
        isOn = !isOn;

        Debug.Log("Button clicked, state is now: " + (isOn ? "On" : "Off"));
    }
}
