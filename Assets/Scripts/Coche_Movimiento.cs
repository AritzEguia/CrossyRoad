using UnityEngine;

public class Coche_Movimiento : MonoBehaviour
{
    public GameObject coche;
    void Update()
    {
        /*SceneManager.sceneInstance.Coche_Movimiento(coche);*/ // Cambiar Instance al SceneManager
    }
    public void OnTriggerEnter(Collider other)
    {
        // GameManager.Instance.Morir(); 
    }
}
