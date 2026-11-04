using TMPro;
using UnityEngine;

public class Puntuacion : MonoBehaviour
{
    [Header("Referencias")]
    public Transform Player;
    public TextMeshProUGUI Texto;

    float posZMax = 0;
    void Update()
    {
        float posZ = Player.position.z;

        if (posZ > posZMax)
        {
            posZMax = posZ;
        }
        Texto.text = posZMax.ToString();
        Debug.Log(Texto);
    }
}