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
    //public class ObstaculoMovil : MonoBehaviour
    //{
        

    //    public class GenerarTerreno : MonoBehaviour
    //    {
    //        [Header("Configuracion de prefabs")]
    //        public List<GameObject> prefabsObstaculos;
    //        public Transform puntoSpawn;

    //        [Header("Datos de generación")]
    //        public float tiempoMinSpawn = 1.5f;
    //        public float tiempoMaxSpawn = 4f;
    //        public float velocidadMin = 5f;
    //        public float velocidadMax = 10f;
            
            
    //        private float velocidadCarril;
    //        private int direccionCarril;

    //        void Start()
    //        {
    //            direccionCarril = Random.value > 0.5f ? 1 : -1;
    //            velocidadCarril = Random.Range(velocidadMin, velocidadMax);

    //            if (direccionCarril < 0)
    //            {
    //                puntoSpawn.localPosition = new Vector3(-puntoSpawn.localPosition.x, puntoSpawn.localPosition.y, puntoSpawn.localPosition.z);
    //            }
    //            Invoke("SpawnObstaculo", Random.Range(tiempoMinSpawn, tiempoMaxSpawn));
    //        }
           
    //        void SpawnearObstaculo()
    //        {
    //            int indiceAleatorio = Random.Range(0, prefabsObstaculos.Count);
    //            GameObject clonObstaculo = Instantiate(prefabsObstaculos[indiceAleatorio], puntoSpawn.position, puntoSpawn.rotation); //Seleccion de obstaculo aleatoria

    //            ObstaculoMovil scriptMovil = clonObstaculo.GetComponent<ObstaculoMovil>();
    //            if (scriptMovil= null) 
    //            {
    //                scriptMovil.Configurar(velocidadCarril, direccionCarril);
    //            }
    //            float siguienteTiempo = Random.Range(tiempoMinSpawn, tiempoMaxSpawn);
    //            Invoke("SpawnObstaculo", siguienteTiempo);
    //        }
    //    }
    //}
}
