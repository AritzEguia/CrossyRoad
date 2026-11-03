using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private GameInput inputActions;
    private Vector2 moveInput;
    private bool isMoving;

    [SerializeField] private float moveDistance = 1f; // Distancia de cada salto
    [SerializeField] private LayerMask CapasObstaculos = ~0; // Capas que bloquean (por defecto todas)
    [SerializeField][Range(0.1f, 1f)] private float TamañoCollider = 0.9f; // Reduce un poco la caja para no chocar con suelo/paredes pegadas

    private Collider playerCollider;

    void Awake()
    {
        inputActions = new GameInput();
        playerCollider = GetComponentInChildren<Collider>();
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

            // Rota al jugador (aunque no pueda avanzar, mira hacia donde lo intenta)
            transform.rotation = Quaternion.LookRotation(targetDirection);

            // Si hay un collider SIN trigger en la casilla de destino, no se mueve
            if (IsBlocked(targetDirection))
            {
                return;
            }

            // Mueve al jugador en 3D
            transform.position += targetDirection * moveDistance;
        }
    }

    // Comprueba si en la posicion de destino hay algun collider que no sea trigger
    private bool IsBlocked(Vector3 direction)
    {
        Bounds limites = playerCollider != null
            ? playerCollider.bounds
            : new Bounds(transform.position, Vector3.one);

        Vector3 centro = limites.center + direction * moveDistance;
        Vector3 halfExtents = limites.extents * TamañoCollider;

        Collider[] hits = Physics.OverlapBox(
            centro,
            halfExtents,
            Quaternion.identity,
            CapasObstaculos,
            QueryTriggerInteraction.Ignore); // Ignora los triggers

        foreach (Collider hit in hits)
        {
            // Ignora los colliders del propio jugador
            if (hit.transform.IsChildOf(transform)) continue;
            Debug.Log($"Bloqueado por: {hit.name} (isTrigger: {hit.isTrigger})", hit);
            return true;
        }

        return false;
    }
}