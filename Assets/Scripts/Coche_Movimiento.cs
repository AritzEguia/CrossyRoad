using UnityEngine;

public class Coche_Movimiento : MonoBehaviour
{
    void Update()
    {
        // GameManager.Instance.MovimientoObjetos(this.gameObject); // Cambiar Instance al SceneManager
    }
    public void OnTriggerEnter(Collider other)
    {
        // GameManager.Instance.Morir(); 
    }
}
