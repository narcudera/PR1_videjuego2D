using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public int valor = 1;    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  void OnTriggerEnter2D(Collider2D col)
 {

    Debug.Log(col.gameObject.name);
    
    if(col.gameObject.name == "Coin")
    {
         GameManager.puntos += valor;
       gameObject.GetComponent<Animator>().SetBool("obtenCoin", true);
        
       Destroy(this.gameObject, 3.0f);
    }
 }
}


