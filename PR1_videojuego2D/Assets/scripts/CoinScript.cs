using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public int valor = 1; // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start() { }

    // Update is called once per frame
    void Update() { }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name);

        if (col.gameObject.name == "personaje")
        {
            GameManager.puntos += valor;
            AudioManager.Instance.SonarClipUnaVez(AudioManager.Instance.monedas);
            gameObject.GetComponent<Animator>().SetBool("obtenMoneda", true);
            Destroy(this.gameObject, 1.0f);
        }
    }
}
