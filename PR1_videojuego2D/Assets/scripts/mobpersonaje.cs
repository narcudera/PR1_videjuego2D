using UnityEngine;
using UnityEngine.InputSystem;

public class mobpersonaje : MonoBehaviour
{

    int MiNumero = 1;

    float MiNumeroFlotante = 0.8f;

    string MiCadenaDeTexto = "Matadame Por Favor";

    int MiVida = 0;

    public float velocidad = 0.01f;
    public float impulsoSalto = 1.0f;

    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

   

        Vector2 moveInput = InputSystem.actions["Move"].ReadValue<Vector2>();
    
        this.transform.Translate(moveInput.x*velocidad,0,0);


        if(moveInput.x < 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        } 
        else if(moveInput.x > 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = false; 
        }
       

        bool salto = InputSystem.actions["Jump"].WasPressedThisFrame();

        if(salto == true)
        {
         Debug.Log("salto");    
         rb.AddForce(transform.up*impulsoSalto,ForceMode2D.Impulse);
         
        }
   
   
        


    }

  





}
