using UnityEngine;
using System.Collections;

public class Carretera : MonoBehaviour
{
    public GameObject coche;
    public Transform t1;
    public Transform t2;
    public float speed = 2f;
    private float duracion = 5f;

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
        //int posInicial = Random.Range(1, 2);
        int posInicial = 1;
        if (posInicial == 1)
        {
            GameObject g = Instantiate(coche, t1);
            StartCoroutine(Coche_Movimiento(g, posInicial));
            //Reseteo de posiciones
        }
        else
        {
            Instantiate(coche, t2);
        }
        
    }
    public IEnumerator Coche_Movimiento(GameObject coche, float posInicial)
    {
        float elapsedTime = 0;
        float waitTime = 5;

        if (posInicial == 1)
        {
            Vector3 direccion = Vector3.left;
            Vector3 T1 = new Vector3(t1.position.x, t1.position.y, t1.position.z);
            Vector3 T2 = new Vector3(t2.position.x, t2.position.y, t2.position.z);
            while(elapsedTime < waitTime)
            {
                coche.transform.position = Vector3.Lerp(T1, T2, (elapsedTime / waitTime));
                elapsedTime += Time.deltaTime;
                yield return null;  
            }
        }
        else
        {
            coche.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        yield return null;
    }
}
