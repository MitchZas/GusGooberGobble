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
    //[SerializeField] InputHandler inputHandlerScript;
    [SerializeField] AbilityHolder abilityHolderScript;

    private void Start()
    {
        playerInput = new PlayerInput();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            
        }

        if (dm.digRate == 3)
        {
            digBlock.GetComponent<LootBag>().InstantiateLoot(transform.position); // Instinate Loot
            Destroy(digBlock); // Destroy Game Object
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
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Dirt"))
        {
            Input.GetKeyDown(KeyCode.E); // Allow Keyboard input
            Debug.Log("Pressed");

            dirtDig.Play(); // Play the Dig Sound
            dm.digRate++; // Incriment the dig rate           
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

