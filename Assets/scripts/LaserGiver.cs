using UnityEngine;

public class LaserGiver : MonoBehaviour
{
    public GameObject laserPrefab; // Prefab del láser
    private bool hasLaser = false;

    public void OnInteract()
    {
        if (!hasLaser)
        {
            // Instanciar el láser en la cámara
            GameObject laser = Instantiate(laserPrefab, Camera.main.transform);
            laser.transform.localPosition = new Vector3(0, 0, 1); // Ajusta la posición del láser en la cámara
            hasLaser = true;

            Debug.Log("Laser obtained!");
        }
    }
}
