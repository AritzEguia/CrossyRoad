using Unity.VisualScripting;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform playerPosition;
    public float velocity;
    void Start()
    {
        
    }
    void LateUpdate()
    {
        if (playerPosition == null)
            return;

        transform.Translate(Vector3.forward * velocity * Time.deltaTime, Space.World);
        if(transform.position.z > playerPosition.position.z)
        {
           Debug.Log("el jugador esta detras");
        }
    }
}
