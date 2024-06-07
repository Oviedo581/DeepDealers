using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UI : MonoBehaviour
{
    UIDocument menu;
    //Principal
    Button BotonStart;
    Button botonexit;
    Button starboton;

    //Hangar Maquina
    VisualElement hangar;
    Button botonmaquina;
    Label nombremaq;
    Label titulomaq;
    ProgressBar stats;
    ProgressBar statsvelocidad;
    ProgressBar statsescaneo;
    ProgressBar statscosto;
    Button volve_boton;

    private void OnEnable()
    {
        menu = GetComponent<UIDocument>();
        VisualElement root = menu.rootVisualElement;

        //Principal
        BotonStart = root.Q<Button>("stats");
        starboton = root.Q<Button>("Start"); // Asegúrate de que el botón "Start" esté identificado como "Start" en tu archivo .uxml
        botonexit = root.Q<Button>("exit");

        //Stats
        hangar = root.Q<VisualElement>("Derecha");
        botonmaquina = root.Q<Button>("BotonMaquina");
        nombremaq = root.Q<Label>("NombreMaquina");
        titulomaq = root.Q<Label>("TituloMaq");
        stats = root.Q<ProgressBar>("Potencia");
        statsvelocidad = root.Q<ProgressBar>("Velocidad");
        statsescaneo = root.Q<ProgressBar>("Precision");
        statscosto = root.Q<ProgressBar>("Costo");
        volve_boton = root.Q<Button>("Volver");

        //callbacks
        BotonStart.RegisterCallback<ClickEvent>(abrirHangar);
        botonmaquina.RegisterCallback<ClickEvent, int>(seleccionarMaquina, 1);
        volve_boton.RegisterCallback<ClickEvent>(cerrarHangar);
        starboton.RegisterCallback<ClickEvent>(HideUI); // Asigna el evento de clic para el botón "Start"
        botonexit.clicked += ExitGame;
    }

    void abrirHangar(ClickEvent evt)
    {
        hangar.AddToClassList("Derecha-activo");
    }

    void seleccionarMaquina(ClickEvent evt, int modelo)
    {
        switch (modelo)
        {
            case 1:
                nombremaq.text = "INGEACOL LASER C02";
                stats.lowValue = 50;
                statsvelocidad.lowValue = 90;
                statsescaneo.lowValue = 70;
                statscosto.lowValue = 80;
                break;
        }
    }

    void cerrarHangar(ClickEvent evt)
    {
        hangar.RemoveFromClassList("Derecha-activo");
    }

    void HideUI(ClickEvent evt)
    {
        menu.rootVisualElement.style.display = DisplayStyle.None; // Oculta la interfaz
        UnityEngine.Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor en el centro de la pantalla
        UnityEngine.Cursor.visible = false; // Oculta el cursor
    }

    void ShowUI()
    {
        menu.rootVisualElement.style.display = DisplayStyle.Flex; // Muestra la interfaz
        UnityEngine.Cursor.lockState = CursorLockMode.None; // Desbloquea el cursor
        UnityEngine.Cursor.visible = true; // Muestra el cursor
    }

    void ExitGame()
    {
        Application.Quit(); // Quit the application
    }

    void Update()
    {
        // Verificar si se ha presionado la tecla ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowUI(); // Muestra la interfaz
        }
    }
}
