using Unity.VisualScripting;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform player;
    void Start()
    {
        
    }
    void LateUpdate()
    {
        Vector3 cameraPosition = new(player.position.x + 3, 7, player.position.z - 7);
        Camera.main.transform.position = cameraPosition;
    }
}
