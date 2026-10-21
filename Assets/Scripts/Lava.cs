using UnityEngine;
using UnityEngine.SceneManagement;
public class Lava : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter3D(Collider other)
    {
        if(other.CompareTag( "Player"))
        {
            Morir();
        }
    }

    void Morir()
    {
        Debug.Log("Tu alma se ha fundido con la lava");
    }
}


