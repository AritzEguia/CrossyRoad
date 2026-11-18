using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class Lava : MonoBehaviour
{
    public string NomEscena;
    public GameObject barco;
    public Transform t1;
    public Transform t2;
    public float speed = 2f;
    void Start()
    {
        BarcoMovimiento();
    }

    void Update()
    {
        
    }
    private void BarcoMovimiento()
    {
        float posZ = GameManager.Instance.spawningManager.siguienteZ;
        int posInicial = Random.Range(1, 3); //Coge un numero entre 1 y 2 para saber si viene de la derecha o la izquierda
        if (posInicial == 1)
        {
            GameObject g = Instantiate(barco, t1);
            StartCoroutine(Barco_Movimiento(g, posInicial));
            //Reseteo de posiciones
        }
        else if (posInicial == 2)
        {
            GameObject g = Instantiate(barco, t2);
            StartCoroutine(Barco_Movimiento(g, posInicial));
        }

    }
    public IEnumerator Barco_Movimiento(GameObject barco, float posInicial)
    {
        float elapsedTime = 0;
        float waitTime = 5;
        Debug.Log(posInicial);
        Vector3 T1 = new Vector3(t1.position.x, t1.position.y, t1.position.z);
        Vector3 T2 = new Vector3(t2.position.x, t2.position.y, t2.position.z);
        if (posInicial == 1)
        {
            while (this.gameObject.activeInHierarchy)
            {
                while (elapsedTime < waitTime)
                {
                    barco.transform.position = Vector3.Lerp(T1, T2, (elapsedTime / waitTime));
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }
                barco.transform.position = T1;
                elapsedTime = 0;
            }
        }
        else
        {
            while (this.gameObject.activeInHierarchy)
            {
                while (elapsedTime < waitTime)
                {
                    barco.transform.position = Vector3.Lerp(T2, T1, (elapsedTime / waitTime));
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }
                barco.transform.position = T2;
                elapsedTime = 0;
            }
        }
        yield return null;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            GameManager.Instance.Morir(NomEscena);
        }
    }
}
