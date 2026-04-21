using UnityEngine;

public class Bala : MonoBehaviour
{
    GameObject personaje;

    public GameObject Disparo;

    bool direccionPersonaje;

    public float velocidadBala = 0.5f;

    float heNacido;
    public float tiempoHastaDestruccion = 5.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        personaje = GameObject.Find("personaje");
        direccionPersonaje = personaje.GetComponent <mobpersonaje>().direccionBalaDerecha;
        heNacido = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.time);
        if(Time.time >= 0.5f)
        {
            Destroy(gameObject);
        }
        
        transform.Rotate(0,0,-0.5f);
        if(direccionPersonaje)
        {
            Disparo.transform.Translate(velocidadBala*Time.deltaTime*0.01f, 0, 0);
            
        }
        else
        {
            Disparo.transform.Translate(velocidadBala*Time.deltaTime*-0.01f, 0, 0);
        }

        if(Time.time >= heNacido + tiempoHastaDestruccion)
        {
            Destroy(Disparo);
        }
    }
}
