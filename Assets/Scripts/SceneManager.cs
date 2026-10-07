using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;
using JetBrains.Annotations; //Para poder usar list
public class SceneManager : MonoBehaviour
{
    void Start()
    {
        
    }
    
    void Update()
    {

    }

    public class ObstaculoMovil : MonoBehaviour
    {
        public float speed = 5f;
        public float limitX = 15f;
        public void Configurar(float nuevaVelocidad, int nuevaDireccion)
        {
              speed = nuevaVelocidad;
            limitX = nuevaDireccion;
        }
        private int direccion;

        void MovimientoObstaculos()
        { 
            if (direccion < 0) 
            {
                transform.Rotate(0f, 180f, 0f);
            }

            transform.Translate(Vector3.right * speed * Time.deltaTime); //Mueve obstaculo en eje X

            if (speed > 0 && transform.position.x > limitX) //Reiniciar posicion si cruza el limite

            {
                transform.position = new Vector3(-limitX, transform.position.y, transform.position.z);
            }
            else if (speed < 0 && transform.position.x < -limitX)
            {
                transform.position = new Vector3(limitX, transform.position.y, transform.position.z);
            }
        }

        public class GenerarTerreno : MonoBehaviour
        {
            [Header("Configuracion de prefabs")]
            public List<GameObject> prefabsObstaculos;
            public Transform puntoSpawn;

            [Header("Datos de generación")]
            public float tiempoMinSpawn = 1.5f;
            public float tiempoMaxSpawn = 4f;
            public float velocidadMin = 5f;
            public float velocidadMax = 10f;
            
            
            private float velocidadCarril;
            private int direccionCarril;

            void Start()
            {
                direccionCarril = Random.value > 0.5f ? 1 : -1;
                velocidadCarril = Random.Range(velocidadMin, velocidadMax);

                if (direccionCarril < 0)
                {
                    puntoSpawn.localPosition = new Vector3(-puntoSpawn.localPosition.x, puntoSpawn.localPosition.y, puntoSpawn.localPosition.z);
                }
                Invoke("SpawnObstaculo", Random.Range(tiempoMinSpawn, tiempoMaxSpawn));
            }
           
            void SpawnearObstaculo()
            {
                int indiceAleatorio = Random.Range(0, prefabsObstaculos.Count);
                GameObject clonObstaculo = Instantiate(prefabsObstaculos[indiceAleatorio], puntoSpawn.position, puntoSpawn.rotation); //Seleccion de obstaculo aleatoria

                ObstaculoMovil scriptMovil = clonObstaculo.GetComponent<ObstaculoMovil>();
                if (scriptMovil= null) 
                {
                    scriptMovil.Configurar(velocidadCarril, direccionCarril);
                }
                float siguienteTiempo = Random.Range(tiempoMinSpawn, tiempoMaxSpawn);
                Invoke("SpawnObstaculo", siguienteTiempo);
            }
        }
    }
}
