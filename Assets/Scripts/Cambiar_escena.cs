using UnityEngine;
using UnityEngine.SceneManagement; 

public class CambioDeEscena : MonoBehaviour
{
    public void CambiarEscenaPorNombre(string Main_Escene)
    {
        SceneManager.LoadScene(Main_Escene);
    }

    public void CargarEscenaPorIndice(int indiceDeLaEscena)
    {
        SceneManager.LoadScene(indiceDeLaEscena);
    }
}
