using UnityEngine;
using System.Collections;

public class Carretera : MonoBehaviour
{
    public GameObject coche;
    public Transform t1;
    public Transform t2;
    public float speed = 2f;

    void Start()
    {
        CocheMovimiento();
    }
    void Update()
    {
        
    }

    private void CocheMovimiento() 
    {
        float posZ = GameManager.Instance.spawningManager.siguienteZ;
        int posInicial = Random.Range(1, 3); //Coge un numero entre 1 y 2 para saber si viene de la derecha o la izquierda
        if (posInicial == 1)
        {
            GameObject g = Instantiate(coche, t1);
            StartCoroutine(Coche_Movimiento(g, posInicial));
            //Reseteo de posiciones
        }
        else if (posInicial == 2) 
        {
            GameObject g = Instantiate(coche, t2);
            StartCoroutine(Coche_Movimiento(g, posInicial));
        }
        
    }
    public IEnumerator Coche_Movimiento(GameObject coche, float posInicial)
    {
        float elapsedTime = 0;
        float waitTime = 5;
        Debug.Log(posInicial);
        Vector3 T1 = new Vector3(t1.position.x, t1.position.y, t1.position.z);
        Vector3 T2 = new Vector3(t2.position.x, t2.position.y, t2.position.z);
        if (posInicial == 1)
        {
            while(this.gameObject.activeInHierarchy)
            { 
                while(elapsedTime < waitTime)
                {
                    coche.transform.position = Vector3.Lerp(T1, T2, (elapsedTime / waitTime));
                    elapsedTime += Time.deltaTime;
                    yield return null;  
                }
                coche.transform.position = T1;
                elapsedTime = 0;
            }
        }
        else
        {
            while (this.gameObject.activeInHierarchy)
            {
                while (elapsedTime < waitTime)
                {
                    coche.transform.position = Vector3.Lerp(T2, T1, (elapsedTime / waitTime));
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }
                coche.transform.position = T2;
                elapsedTime = 0;
            }
        }
        yield return null;
    }
}
