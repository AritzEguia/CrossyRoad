using UnityEngine;

public class Suelo : MonoBehaviour
{

    public GameObject obstaculo;
    public Transform t1;
    public Transform t2;
    public Transform t3;
    public Transform t4;
    public Transform t5;
    public float speed = 2f;

    void Start()
    {
        SpawnObstaculo();
    }

    void Update()
    {
        
    }

    private void SpawnObstaculo()
    {
        float posz = GameManager.Instance.spawningManager.siguienteZ;
        int posIniciail = Random.Range(1, 6); //Coge un numero entre 1 y 5 para saber en que posicion spawnea
    }
}
