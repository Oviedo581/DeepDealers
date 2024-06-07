using UnityEngine;
using UnityEngine.UI;

public class MaterialMenu : MonoBehaviour
{
    public GameObject menuPanel; // Panel del menú
    public Dropdown materialDropdown; // Dropdown para seleccionar material
    public Material[] materials; // Lista de materiales

    void Start()
    {
        // Ocultar el menú al inicio
        menuPanel.SetActive(false);

        // Agregar listeners para el dropdown
        materialDropdown.onValueChanged.AddListener(delegate {
            ChangeMaterial(materialDropdown.value);
        });
    }

    public void ShowMenu()
    {
        menuPanel.SetActive(true);
    }

    void ChangeMaterial(int index)
    {
        // Lógica para cambiar el material
        Debug.Log("Selected material: " + materials[index].name);
        // Puedes agregar aquí la lógica para cambiar el material del objeto a cortar
    }
}
