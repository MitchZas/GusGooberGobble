using UnityEngine;
using UnityEngine.InputSystem;

public class DogController : MonoBehaviour
{
    public InputAction dogControls;

    Vector2 moveDirection = Vector2.zero;

    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    public GameObject poop;
    public AIChase aiChaseScript;

    private void OnEnable()
    {
        dogControls.Enable();
    }

    private void OnDisable()
    {
        dogControls.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = dogControls.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Human")
        {
            moveSpeed = 0;
            aiChaseScript.speed = 0;
        }

        if (other.gameObject.tag == "Poop")
        {
            Destroy(poop);
        }
    }
}
