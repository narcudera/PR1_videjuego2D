using UnityEngine;

public class mobpersonaje : MonoBehaviour
{

    int MiNumero = 1;

    float MiNumeroFlotante = 0.8f;

    string MiCadenaDeTexto = "Matadame Por Favor";

    int MiVida = 0;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      int SumaEntreDecenas = Sumar(10,20);  
    
      Debug.Log("Inicio");
      Debug.Log(SumaEntreDecenas);
      Debug.Log(this.transform.position.x);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Final");
        if(MiVida > 0)
        {Debug.Log("Estoy Vivo");}
        else{Debug.Log("Estoy Mortaja");}
    }

    



    int Sumar (int num1, int num2)
{
       int suma = num1 + num2;

       return suma; 
     
}
}
