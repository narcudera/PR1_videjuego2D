using UnityEngine;
using UnityEngine.InputSystem;

public class mobpersonaje : MonoBehaviour
{

   

    public float velocidad = 0.01f;
    public float impulsoSalto = 1.0f;

    bool puedoSaltar = false;


    Rigidbody2D rb;

    Animator controlAnimacion;

    GameObject respawn;

    GameObject Spikes;

    public bool direccionBalaDerecha = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    rb = GetComponent<Rigidbody2D>();
    controlAnimacion = GetComponent<Animator>();
    respawn = GameObject.Find("Respawn");
    transform.position = respawn.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
       //
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
       
        if(moveInput.x != 0)
        {
        controlAnimacion.SetBool("activaCamina", true); 
        }
        else
        {
        controlAnimacion.SetBool("activaCamina", false);
        }
        //fgfggffg
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
         
         rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);    
         rb.AddForce(transform.up * impulsoSalto, ForceMode2D.Impulse);
         puedoSaltar = false;
        
        }
        
   
        
        bool disparo = InputSystem.actions["Attack"].WasPressedThisFrame();
        if(disparo == true)
        {
            Debug.Log("disparo");
        }
        

    }
    void OnTriggerEnter2D(Collider2D col)
   { 
    Debug.Log("Trigger col: " + col.gameObject.name);

    if(col.gameObject.name == "dead")
    {
        Muerte();
        Respawn();
    }

    void Muerte()

    {
        GameManager.vidas -= 1;
        transform.position = respawn.transform.position;
    }

   }
   public void Respawn()
   {
     GameManager.vidas -= 1;
        Debug.Log("Vidas restantes: " + GameManager.vidas);
        transform.position = respawn.transform.position;
   }
}
