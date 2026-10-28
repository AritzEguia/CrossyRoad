using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private GameInput inputActions;
    private Vector2 moveInput;
    private bool isMoving;

    [SerializeField] private float moveDistance = 1f; // Distancia de cada salto

    void Awake()
    {
        inputActions = new GameInput();
    }
    //Ejecuta el codigo cuando se inicia el juego
    void OnEnable()
    {
        inputActions.Player.Move.performed += OnMovePerformed; //Avisa cuando se aprieta la tecla
        inputActions.Player.Move.canceled += OnMoveCanceled; //Cuando se suelta
        inputActions.Player.Enable();
    }
    //Cuando el jugador muere se para todo
    void OnDisable()
    {
        inputActions.Player.Move.performed -= OnMovePerformed;
        inputActions.Player.Move.canceled -= OnMoveCanceled;
        inputActions.Player.Disable();
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        //Pa que no puedas usar dos teclas a la vez
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
        //Decide a dnd se mueve
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

            // Mueve al jugador en 3D
            transform.position += targetDirection * moveDistance;

            // Rota al jugador
            transform.rotation = Quaternion.LookRotation(targetDirection);
        }
    }
}