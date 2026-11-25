using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public Transform anclaje;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Transform objetivo = anclaje != null ? anclaje : transform;
            collision.transform.SetParent(objetivo);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Transform objetivo = anclaje != null ? anclaje : transform;

            if (collision.transform.parent == objetivo)
            {
                collision.transform.SetParent(null);
            }
        }
    }
}
