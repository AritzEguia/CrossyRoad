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
    [SerializeField] private int filasIniciales = 20;
    [SerializeField] private float distanciaEntreFilas = 1f;
    private List<GameObject> filas = new List<GameObject>();

    private GameObject[] terrenoPrefabs;
    private float siguienteZ;

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
        int index = Random.Range(0, terrenoPrefabs.Length);

        GameObject fila = Instantiate(terrenoPrefabs[index], new Vector3(0, 0, siguienteZ), Quaternion.identity);

        filas.Add(fila);
        siguienteZ += distanciaEntreFilas;
    }
    void ReciclarFila(GameObject fila)
    {
        fila.SetActive(false);

        fila.transform.position = new Vector3(0, 0, siguienteZ);

        siguienteZ += distanciaEntreFilas;

        fila.SetActive(true);
    }
}
