using UnityEngine;
using UnityEngine.InputSystem;

public class Movimiento : MonoBehaviour
{
    private Vector2 movimiento;
    void Start()
    {

    }   

    public void OnForward(InputValue value)
    {
        movimiento = value.Get<Vector2>();
    }
    public void OnDown(InputValue value)
    {
        movimiento = value.Get<Vector2>();
    }
    public void OnRight(InputValue value)
    {
        movimiento = value.Get<Vector2>();
    }
    public void OnLeft(InputValue value)
    {
        movimiento = value.Get<Vector2>();
    }
    private void Update()
    {
        transform.Translate(movimiento.x * Time.deltaTime * 5, 0, movimiento.y * Time.deltaTime * 5);
    }
}
