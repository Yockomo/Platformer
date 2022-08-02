using MyNamespace;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public Vector2 Movement { get; private set; }
    public bool Jump { get; set; }
    public bool Atack { get; private set; }

    private void Update()
    {
        HandleInputs();
    }

    private void HandleInputs()
    {
        HandleMovementInput();
        HandleJumpInput();
        HandleAtackInput();
    }
    
    private void HandleMovementInput()
    {
        var horizontalInput = Input.GetAxis(GlobalStrings.HorizontalAxis);
        var verticalInput = Input.GetAxis(GlobalStrings.VerticalAxis);
        Movement.Set(horizontalInput,verticalInput);
    }

    private void HandleJumpInput()
    {
        Jump = Input.GetKeyDown(KeyCode.Space);
    }

    private void HandleAtackInput()
    {
        Atack = Input.GetKey(KeyCode.Mouse0);
    }
}
