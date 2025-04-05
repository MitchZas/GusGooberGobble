using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DogController : MonoBehaviour
{
    private PlayerInput playerInput;

    private Rigidbody2D rb;

    Vector2 moveDirection = Vector2.zero;

    public float moveSpeed = 5f;

    public GameObject digBlock;
    public GameObject nextRoundUI;
    [SerializeField] GameObject gate;
    
    public AudioSource dirtDig;
   
    public AIChase aiChaseScript;

    Vector2 moveInput;

    [SerializeField] DroppingsManager dm;
    [SerializeField] InputHandler inputHandlerScript;
    [SerializeField] AbilityHolder abilityHolderScript;

    [SerializeField] Image ZoomiesIcon;

    private void Start()
    {
        playerInput = new PlayerInput();
        rb = GetComponent<Rigidbody2D>();
        ZoomiesIcon.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            Debug.Log("Pressed");
            dirtDig.Play();
            dm.digRate++;
        }

        if (dm.droppingsCount == 4)
        {
            Destroy(gate);
        }
    }

    void FixedUpdate()
    { 
        rb.AddForce(moveInput * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Human")
        {
            GameOver();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Poop"))
        {
            Destroy(other.gameObject);
            dm.droppingsCount++;
        }

        if (other.gameObject.CompareTag("Pickup"))
        {
            ZoomiesIcon.gameObject.SetActive(true);
            Destroy(other.gameObject);
        }
    }

    public GameObject gameOverPanel;
    void GameOver()
    {
        moveSpeed = 0;
        aiChaseScript.speed = 0;
        gameOverPanel.SetActive(true);
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        //rb.linearVelocity = inputValue.Get<Vector2>() * moveSpeed;
    }
}

