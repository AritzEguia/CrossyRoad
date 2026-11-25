using UnityEngine;

public class Suelo : MonoBehaviour
{

    public GameObject obstaculo;
    public Transform t1;
    public Transform t2;
    public Transform t3;
    public Transform t4;
    public Transform t5;

    void Start()
    {
        SpawnObstaculo();
    }

    void Update()
    {

    }

    private void SpawnObstaculo()
    {
        int pos = Random.Range(1, 6);
        if (pos == 1)
        {
            Instantiate(obstaculo, new Vector3(t1.transform.position.x, 0.5f, t1.transform.position.z), Quaternion.identity);
        }
        else if(pos == 2)
        {
            Instantiate(obstaculo, new Vector3(t2.transform.position.x, 0.5f, t2.transform.position.z), Quaternion.identity);
        }
        else if (pos == 3)
        {
            Instantiate(obstaculo, new Vector3(t3.transform.position.x, 0.5f, t3.transform.position.z), Quaternion.identity);
        }
        else if (pos == 4)
        {
            Instantiate(obstaculo, new Vector3(t4.transform.position.x, 0.5f, t4.transform.position.z), Quaternion.identity);
        }
        else if (pos == 5)
        {
            Instantiate(obstaculo, new Vector3(t5.transform.position.x, 0.5f, t5.transform.position.z), Quaternion.identity);
        }
    }
}