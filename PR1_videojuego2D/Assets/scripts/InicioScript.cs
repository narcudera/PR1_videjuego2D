using UnityEngine;
using UnityEngine.SceneManagement;

public class InicioScript : MonoBehaviour
{
    public GameObject panelInicio;
    
    public GameObject panelSettings;
    
    public AudioClip botonSonidoFX;
    
    GameObject AudioManagerObj;

    AudioSource AudioManagerSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        panelSettings.SetActive(false);
        AudioManagerSource = AudioManagerObj.GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update() { }

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
        //AudioManagerObj.GetComponent<AudioSource>().SonarBoton();
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
