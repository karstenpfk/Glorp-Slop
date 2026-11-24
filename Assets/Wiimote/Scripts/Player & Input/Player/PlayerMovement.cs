
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent( typeof( Rigidbody ) )]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5f;

    private GameManager gameManager;
    private Rigidbody rb;
    private Vector2 movement;

    private void Awake ()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = FindFirstObjectByType<GameManager>();
    }

    public void Interact ()
    {
        Debug.Log( "Interact pressed!" );
    }

    public void Move ( InputAction.CallbackContext context )
    {
        movement = context.ReadValue<Vector2>();
        Debug.Log( "Joystick movement: " + movement );
    }

    public void AddIngredient ( GameObject ingredient )
    {
        gameManager.burgerIngredients.Add( ingredient );
    }

    private void FixedUpdate ()
    {
        Vector3 direction = new Vector3( movement.x, 0f, movement.y );

        rb.MovePosition(
            rb.position + direction * playerSpeed * Time.fixedDeltaTime
        );
    }
}
