using UnityEngine;

public class Lava : MonoBehaviour
{
    public string NomEscena;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            //GameManager.Instance.Morir(NomEscena);
        }
    }
}
