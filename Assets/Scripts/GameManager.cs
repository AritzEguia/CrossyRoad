using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public SpawningManager spawningManager;


    public GameObject Player;
    
    Vector3 posicionInicio = new Vector3( 0.5f, 1, 5.5f);
    Quaternion rotacionInicial = Quaternion.identity;
    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(Player);
    }
    void Start()
    {
        Instantiate(Player, posicionInicio, rotacionInicial);
    }

    void Update()
    {
        
    }

    public void Morir(string NomEscena)
    {
        Destroy(Player);
        //////////////////SceneManager.LoadScene(NomEscena);
    }

}
