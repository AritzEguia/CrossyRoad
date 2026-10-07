using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public SceneManager SceneManager;

    public GameObject Player;
    
    Vector3 posicionInicio = new Vector3(0, 5, 0);
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
    
}
