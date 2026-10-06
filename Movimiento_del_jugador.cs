using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private GameInput inputActions;
    private Vector2 moveInput;
    private bool isMoving;

    [SerializeField] private float moveDistance = 1f; //Esto mide la distancia del salto

    void Awake()
    {
        inputActions = new GameInput();
    }

    void OnEnable()
    {
        inputActions.Player.Move.performed += OnMovePerformed;
        inputActions.Player.Move.canceled += OnMoveCanceled;
        inputActions.Player.Enable();
    }

    void OnDisable()
    {
        inputActions.Player.Move.performed -= OnMovePerformed;
        inputActions.Player.Move.canceled -= OnMoveCanceled;
        inputActions.Player.Disable();
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        // Si ya se está presionando una dirección, evitamos repetir hasta que suelte o termine el salto
        if (!isMoving)
        {
            ProcessMovement();
        }
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        moveInput = Vector2.zero;
        isMoving = false;
    }

    private void ProcessMovement()
    {
        // Determinamos la dirección principal (evita diagonales)
        Vector3 targetDirection = Vector3.zero;

        if (Mathf.Abs(moveInput.x) > Mathf.Abs(moveInput.y))
        {
            targetDirection = moveInput.x > 0 ? Vector3.right : Vector3.left;
        }
        else if (Mathf.Abs(moveInput.y) > Mathf.Abs(moveInput.x))
        {
            targetDirection = moveInput.y > 0 ? Vector3.forward : Vector3.back;
        }

        if (targetDirection != Vector3.zero)
        {
            isMoving = true;

            // Mueve al jugador instantáneamente una unidad en el eje 3D
            transform.position += targetDirection * moveDistance;

            // Rota al personaje hacia la dirección del movimiento
            transform.rotation = Quaternion.LookRotation(targetDirection);
        }
    }
}