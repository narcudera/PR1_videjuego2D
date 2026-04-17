using UnityEngine;

public class Bala : MonoBehaviour
{
    GameObject personaje;

    public GameObject Disparo;

    bool direccionPersonaje;

    public float velocidadBala = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        personaje = GameObject.Find("personaje");
        direccionPersonaje = personaje.GetComponent <mobpersonaje>().direccionBalaDerecha;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,-0.5f);
        if(direccionPersonaje)
        {
            Disparo.transform.Translate(0.01f, 0, 0);
            
        }
        else
        {
            Disparo.transform.Translate(-0.01f, 0, 0);
        }
    }
}
