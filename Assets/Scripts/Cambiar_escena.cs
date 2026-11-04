using UnityEngine;
using UnityEngine.SceneManagement; 

public class CambioDeEscena : MonoBehaviour
{
    public void CambiarEscenaPorNombre(string Main_Escene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(Main_Escene);
    }

    public void CargarEscenaPorIndice(int indiceDeLaEscena)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(indiceDeLaEscena);
    }
}
