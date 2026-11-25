using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carretera : MonoBehaviour
{
    public GameObject coche;
    public Transform t1;
    public Transform t2;
    public Queue<GameObject> coches = new Queue<GameObject>();

    void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject g = Instantiate(coche);
            g.SetActive(false);
            coches.Enqueue(g);
        }
        StartCoroutine(GenerarCochesEnCola());
    }
    void Update()
    {
        
    }
    private IEnumerator GenerarCochesEnCola()
    {
        int direccion = Random.Range(1, 3);
        Transform origen = (direccion == 1) ? t1 : t2;
        Transform destino = (direccion == 1) ? t2 : t1;

        while (this.gameObject.activeInHierarchy)
        {
            float tiempoEsperaInicial = Random.Range(0, 3);
            yield return new WaitForSeconds(tiempoEsperaInicial);
            if (coches.Count > 0)
            {
                GameObject barcoActual = coches.Dequeue();
                barcoActual.transform.position = origen.position;
                barcoActual.SetActive(true);

                StartCoroutine(MoverCocheIndividual(barcoActual, origen.position, destino.position));
            }
            float tiempoEsperaFinal = Random.Range(1.5f, 3.0f);
            yield return new WaitForSeconds(tiempoEsperaFinal);
        }
    }
    private IEnumerator MoverCocheIndividual(GameObject cocheInstancia, Vector3 origen, Vector3 destino)
    {
        float elapsedTime = 0f;
        float waitTime = 5f;

        while (elapsedTime < waitTime)
        {
            cocheInstancia.transform.position = Vector3.Lerp(origen, destino, elapsedTime / waitTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        cocheInstancia.SetActive(false);
        coches.Enqueue(cocheInstancia);
    }
    
}
