using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    InputAction moveAction;
    InputAction jumpAction;

    Rigidbody rb;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    private bool isGrounded;

    private void Start() {
        isGrounded = true;

        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");

        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        Vector3 moveVector = new Vector3(moveInput.x, 0, moveInput.y);
        float jump = jumpAction.ReadValue<float>();

        if (isGrounded) {
            // Move Code
            rb.AddForce(moveVector * moveSpeed * Time.fixedDeltaTime);

            // Jump Code
            if (jump != 0 && isGrounded) {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }

    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.layer == 6) { 
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision) {
        if (collision.gameObject.layer == 6) {
            isGrounded = false;
        }
    }

}
