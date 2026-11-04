using UnityEngine;

public class Barco_Moviento : MonoBehaviour
{
    public GameObject barco;
    void Update()
    {
        /*SceneManager.sceneInstance.Barco_Movimiento(coche);*/ // Cambiar Instance al SceneManager
    }
    public void OnTriggerEnter(Collider other)
    {
        // GameManager.Instance.Morir(); 
    }
}
