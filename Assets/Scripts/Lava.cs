using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Lava : MonoBehaviour
{
    public string NomEscena;
    public GameObject barco;
    public Transform t1;
    public Transform t2;
    public Queue<GameObject> barcos = new Queue<GameObject>();
    public static bool valorTurno = false;
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject g = Instantiate(barco);
            g.SetActive(false);
            barcos.Enqueue(g);
        }
        valorTurno = !valorTurno;
        StartCoroutine(GenerarBarcosEnCola());
    }
    private IEnumerator GenerarBarcosEnCola()
    {
        Transform origen;
        Transform destino;
        origen = (valorTurno == false) ? t1 : t2;
        destino = (valorTurno == false) ? t2 : t1;

        while (this.gameObject.activeInHierarchy)
        {
            float tiempoEsperaInicial = Random.Range(0, 3);
            yield return new WaitForSeconds(tiempoEsperaInicial);
            if (barcos.Count > 0)
            {
                GameObject barcoActual = barcos.Dequeue(); 
                barcoActual.transform.position = origen.position;
                barcoActual.SetActive(true);

                StartCoroutine(MoverBarcoIndividual(barcoActual, origen.position, destino.position));
            }
            float tiempoEsperaFinal = Random.Range(3.0f, 6.0f);
            yield return new WaitForSeconds(tiempoEsperaFinal);
        }
    }
    private IEnumerator MoverBarcoIndividual(GameObject barcoInstancia, Vector3 origen, Vector3 destino)
    {
        float elapsedTime = 0f;
        float waitTime = 10f;

        while (elapsedTime < waitTime)
        {
            barcoInstancia.transform.position = Vector3.Lerp(origen, destino, elapsedTime / waitTime);
            elapsedTime += Time.deltaTime;
            yield return null; 
        }

        barcoInstancia.SetActive(false);
        barcos.Enqueue(barcoInstancia);
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            GameManager.Instance.Morir("Muerte");
        }
    }
}
