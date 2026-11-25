using Unity.VisualScripting;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public GameObject playerPosition;
    public float velocity;

    void Start()
    {
       playerPosition = GameObject.FindWithTag("Player");
    }
    void LateUpdate()
    {
        if (playerPosition == null)
            return;

        transform.Translate(Vector3.forward * velocity * Time.deltaTime, Space.World);
        if(transform.position.z > playerPosition.transform.position.z)
        {
           Debug.Log("el jugador esta detras");
           GameManager.Instance.Morir("Muerte");
        }

    }
}
