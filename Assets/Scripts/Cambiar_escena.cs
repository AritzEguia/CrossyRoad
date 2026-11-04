using UnityEngine;
using UnityEngine.SceneManagement; 

public class CambioDeEscena : MonoBehaviour
{
    public void CambiarEscenaPorNombre(string Main_EscenePrincipal)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(Main_EscenePrincipal);
    }

    public void CargarEscenaPorIndice(int indiceDeLaEscena)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(indiceDeLaEscena);
    }
}
