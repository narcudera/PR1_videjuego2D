using UnityEngine;

public class Enemigo : MonoBehaviour
{
    GameObject personaje;

    string estado = "patrulla";

    float distanciaPatrulla = 2.0f;

    public float velocidadPatrulla = 0.01f;

    Vector3 posicionInicial;
    Vector3 posicionLimitIzq, posicionLimitDcha;

    bool dirPatrullaDcha = true;

    public float distaciaAtaque = 1.0f;
    public float velocidadAtaque = 1.0f;
    public float distanciaEvitar = 3.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        personaje = GameObject.FindWithTag("Player");
        posicionInicial = transform.position;
        posicionLimitIzq = new Vector3(posicionInicial.x - distanciaPatrulla, posicionInicial.y, posicionInicial.z);
        posicionLimitDcha = new Vector3(posicionInicial.x + distanciaPatrulla, posicionInicial.y, posicionInicial.z);
    }

    // Update is called once per frame
    void Update()
    {
       float distancia = Vector3.Distance(transform.position, personaje.transform.position);
       
      if(distancia <= distaciaAtaque)
       {
        estado = "ataque";
       }

       if(distancia >= distanciaEvitar)
       {
        estado = "patrulla";
       }
       
       if(estado == "patrulla")
       {
             
            if(transform.position.x >= posicionLimitDcha.x)
            {
                dirPatrullaDcha = false;
                this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            if(transform.position.x <= posicionLimitIzq.x)
            {
                dirPatrullaDcha = true;
                this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
           

            if(dirPatrullaDcha == true)
            {
                 transform.Translate(velocidadPatrulla, 0, 0);
            }
            else
            {
                 transform.Translate(velocidadPatrulla*-1, 0, 0);
            }
           
           if(estado == "ataque")
           {
            transform.position = Vector3.MoveTowards(transform.position, personaje.transform.position, velocidadAtaque);
           }
       }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("dead");
            GameManager.vidas -= 1;
            personaje.GetComponent<mobpersonaje>().Respawn;
        }
        Debug.Log(col.gameObject.name);

        if(col.gameObject.name == "fuego")
        {
            Destroy(this.gameObject, 0.5f);
            Destroy(col.gameObject, 0.5f);
        }

    }
}
