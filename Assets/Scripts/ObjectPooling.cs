using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    [SerializeField] private List<GameObject> carrilesPrefab;
    [SerializeField] private List<GameObject> carriles;
    [SerializeField] private int PoolSize = 20;
    void Start()
    {
        for (int i = 0; i < PoolSize; i++)
        {
            CrearLista();
        }
        Carriles();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CrearLista()
    {
        int index = Random.Range(0, carrilesPrefab.Count);

        GameObject Carril = carrilesPrefab[index];

        carriles.Add(Carril);
    }
    void Carriles()
    {
        for (int i = 0; i < PoolSize; i++)
        {
            Debug.Log("Carril " + carriles[i].name);
        }
    }
}
