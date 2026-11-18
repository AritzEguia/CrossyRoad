using TMPro;
using UnityEngine;

public class Puntuacion : MonoBehaviour
{
    [Header("Referencias")]
    public Transform Player;
    public TextMeshProUGUI Texto;

    float posZMax = 0;
    float puntuaciónActual = 0;
    float posZinicio;

    private void Start()
    {
        posZinicio = Player.position.z;
        ActualizarTexto();
    }
    void Update()
    {
        float distanciaActual = Player.position.z - posZinicio;

        if (distanciaActual > Player.position.z)
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