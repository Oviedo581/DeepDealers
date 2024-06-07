using UnityEngine;

public class LaserCutter : MonoBehaviour
{
    public Material selectedMaterial; // Material seleccionado para cortar

    void Update()
    {
        // Detectar si el láser está activado y disparando
        if (Input.GetMouseButton(0)) // Botón izquierdo del ratón
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Realizar el raycast
            if (Physics.Raycast(ray, out hit))
            {
                // Lógica para cortar el material
                if (hit.collider.GetComponent<Renderer>().sharedMaterial == selectedMaterial)
                {
                    Debug.Log("Cutting material: " + selectedMaterial.name);
                    // Aquí puedes agregar la lógica para cortar el material
                }
            }
        }
    }
}

