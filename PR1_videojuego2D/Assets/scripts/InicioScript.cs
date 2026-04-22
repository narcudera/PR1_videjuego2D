using UnityEngine;
using UnityEngine.SceneManagement;

public class InicioScript : MonoBehaviour
{


    public GameObject panelInicio;
    public GameObject panelSettings;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        panelSettings.SetActive(false);
    }

    public void Inicio()
    {
     SceneManager.LoadScene("juego");
    }

     public void showSettings()
    {
        panelSettings.SetActive(true);
        panelInicio.SetActive(false);
    }

    public void exitSetting()
    {
         panelSettings.SetActive(false);
        panelInicio.SetActive(true);
    }

    public void exitGame()

    {
        Application.Quit();
    }
}
