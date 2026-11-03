using UnityEngine;

public class MenuDePausa : MonoBehaviour
{
    public GameObject menuPausa;
    public bool juegoPausado = false;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                reanudar();
            }
            else
            {
                pausar();
            }
        }
    }
    public void reanudar()
    {
        menuPausa.SetActive(false);
        Time.timeScale = 1;
        juegoPausado = false;
    }
    public void pausar()
    {
        menuPausa.SetActive(true);
        Time.timeScale = 0;
        juegoPausado = true;
    }
}
