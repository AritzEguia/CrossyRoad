using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningManager : MonoBehaviour
{
    [Header("Prefabs del terreno")]
    [SerializeField] private GameObject grassPrefab;
    [SerializeField] private GameObject lavaPrefab;
    [SerializeField] private GameObject roadPrefab;

    [Header("Configuracion")]
    [SerializeField] private Transform player;
    [SerializeField] private Camera camara;
    [SerializeField] private int filasIniciales = 25;
    [SerializeField] private float distanciaEntreFilas = 1f;
    private List<GameObject> filas = new List<GameObject>();

    private GameObject[] terrenoPrefabs;
    public float siguienteZ;
    int contador = 0;
    void Start()
    {
        terrenoPrefabs = new GameObject[] { grassPrefab, lavaPrefab, roadPrefab};
        for (int i = 0; i < filasIniciales; i++)
        {
            CrearFila();
        }
    }
    void Update()
    {
        foreach (GameObject fila in filas)
        {
            if (fila.activeSelf && fila.transform.position.z < camara.transform.position.z)
            {
                ReciclarFila(fila);
            }
        }
    }
    void CrearFila()
    {
        
        if (contador < 5)
        {
            GameObject fila = Instantiate(terrenoPrefabs[0], new Vector3(0, 0, siguienteZ), Quaternion.identity);
            siguienteZ += distanciaEntreFilas;
            contador++;
        }
        else
        {
            int index = Random.Range(0, terrenoPrefabs.Length);

            GameObject fila = Instantiate(terrenoPrefabs[index], new Vector3(0, 0, siguienteZ), Quaternion.identity);

            filas.Add(fila);
            siguienteZ += distanciaEntreFilas;
        }
    }
    void ReciclarFila(GameObject fila)
    {
        fila.SetActive(false);

        int index = Random.Range(0, terrenoPrefabs.Length);

        fila = Instantiate(terrenoPrefabs[index], new Vector3(0, 0, siguienteZ), Quaternion.identity);
        filas.Add(fila);

        siguienteZ += distanciaEntreFilas;

        fila.SetActive(true);
    }
}
