using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public GameObject Player;
    
    Vector3 posicionInicio = new Vector3(0, 5, 0);
    Quaternion rotacionInicial = Quaternion.identity;

    void Start()
    {
        Instantiate(Player, posicionInicio, rotacionInicial);
    }

    void Update()
    {
        
    }

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(Player);
    }

    void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
