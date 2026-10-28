using UnityEngine;
using TMPro;

public class Puntuacion : MonoBehaviour
{
    [Header("Referencias")]
    public Transform Player;
    public TextMeshProUGUI Texto;

    float posZMax = 0;
    public void Update()
    {
        float posZ = transform.position.z;

        if (posZ > posZMax)
        {
            posZMax = posZ;
        }
        Texto.text = posZMax.ToString();
    }
}
