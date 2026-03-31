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

    bool puedoSaltar = false;


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
       

       RaycastHit2D hit = Physics2D.Raycast(transform.position,Vector2.down,0.5f);

       Debug.DrawRay(transform.position,Vector2.down*0.5f,Color.red);

       if(hit.collider == true)
       {
        puedoSaltar = true;
       }
       else
       {
        puedoSaltar = false;
       }
    
       
       
        bool salto = InputSystem.actions["Jump"].WasPressedThisFrame();

        if(salto == true && puedoSaltar == true)
        {
         Debug.Log("salto");    
         rb.AddForce(transform.up*impulsoSalto,ForceMode2D.Impulse);
         this.GetComponent<SpriteRenderer>().color = Color.red;
        transform.localScale = new Vector3(1,1,1);
        }
        else
        {
        this.GetComponent<SpriteRenderer>().color = Color.white;
        transform.localScale = new Vector3(2,2,1);
        }
   
        
        bool disparo = InputSystem.actions["Attack"].WasPressedThisFrame();

        

    }

  





}
