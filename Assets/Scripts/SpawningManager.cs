using UnityEngine;
using System.Collections;

public class SpawningManager : MonoBehaviour
{
    public GameObject[] terrenoPrefabs;
    public Transform player;
    private int aumento = 0;
    private Vector3 posicion;
    private bool spawning = false;

 
    void Start()
    {
    }
    void Update()
    {
        if (!spawning)
        {
            spawning = true;
            StartCoroutine(SpawnTerrain());
        }
    }
    IEnumerator SpawnTerrain()
    {
        while (true)
        {
            posicion = new Vector3(0, 0, aumento);
            int index = Random.Range(0, terrenoPrefabs.Length);
            Instantiate(terrenoPrefabs[index], posicion, Quaternion.identity);
            aumento++;
            yield return new WaitForSeconds(1f);
        }
    }
}
