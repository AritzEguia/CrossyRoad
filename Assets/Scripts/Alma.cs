using UnityEngine;
using UnityEngine.SceneManagement;

public class Alma : MonoBehaviour
{
    public string nomEscena;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(nomEscena);
        }
    }
}
