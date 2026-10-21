using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;
using JetBrains.Annotations; //Para poder usar list
public class SceneManager : MonoBehaviour
{
    public float speed = 5f;
    public float limitX = 15f;
    private int direccion;
    public static SceneManager sceneInstance;
    void Awake()
    {
        if (sceneInstance == null) sceneInstance = this;
    }
    void Start()
    {
        
    }
    
    void Update()
    {

    }
    public IEnumerator Coche_Movimiento(GameObject coche){
        if (direccion < 0)
        {
            coche.transform.Rotate(0f, 180f, 0f);
        }

        coche.transform.Translate(Vector3.right * speed * Time.deltaTime); //Mueve obstaculo en eje X

        if (speed > 0 && transform.position.x > limitX) //Reiniciar posicion si cruza el limite

        {
            coche.transform.position = new Vector3(-limitX, transform.position.y, transform.position.z);
        }
        else if (speed < 0 && transform.position.x < -limitX)
        {
            coche.transform.position = new Vector3(limitX, transform.position.y, transform.position.z);
        }
        yield return new WaitForSeconds(2f);
    }
    public void coche_Movimiento(GameObject coche){
        StartCoroutine(Coche_Movimiento(coche));
    }
}
