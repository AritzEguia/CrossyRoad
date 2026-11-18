using TMPro;
using UnityEngine;

public class Puntuacion : MonoBehaviour
{
    [Header("Referencias")]
    public TextMeshProUGUI Texto;

    private Transform Player;
    private bool player = false;
    float posZMax = 0f;
    float puntuaciónActual = 0;
    float posZinicio;

    private void Start()
    {
        ActualizarTexto();
    }
    void Update()
    {
        if (Player == null) 
        {
            GameObject objPlayer = GameObject.FindGameObjectWithTag("Player");

            if (objPlayer != null)
            {
                Player = objPlayer.transform;
                if (!player)
                {
                    posZinicio = Player.position.z;
                    player = true;
                }

            }
            return;
        }

        float distanciaActual = Player.position.z - posZinicio;

        if (distanciaActual > posZMax)
        {
            posZMax = distanciaActual;

            int nuevosPuntos = Mathf.FloorToInt(posZMax);

            if (nuevosPuntos > puntuaciónActual)
            {
                puntuaciónActual = nuevosPuntos;
                ActualizarTexto();
            }
        }
    }
    private void ActualizarTexto()
    {
        Texto.text = puntuaciónActual.ToString();
    }
}