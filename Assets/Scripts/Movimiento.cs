using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public int camino;
    public int lateral;

    int posicionZ;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            avanzar();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            retroceder();
        }
    }
    public void avanzar()
    {
        posicionZ++;
        if (posicionZ > camino)
        {
            camino = posicionZ;
        }
    }
    public void retroceder()
    {
        if (posicionZ > camino - 3)
        {
            posicionZ--;
        }
    }
}
