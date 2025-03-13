using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DogController : MonoBehaviour
{
    public InputAction dogControls;

    Vector2 moveDirection = Vector2.zero;

    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    public GameObject digBlock;
    public GameObject nextRoundUI;
    public AudioSource dirtDig;
   
    public AIChase aiChaseScript;

    [SerializeField] DroppingsManager dm;
    [SerializeField] CardShowUI cardShowScript;
    [SerializeField] InputHandler inputHandlerScript;

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

        //if (dm.digRate == 3)
        //{
            //cardShowScript.EnableCardShow();
       // }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cardShowScript.EnableCardShow();
        }

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            Debug.Log("Pressed");
            dirtDig.Play();
            dm.digRate++;
        }

        if (dm.droppingsCount == 4)
        {
            nextRoundUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
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
    }

    public GameObject gameOverPanel;
    void GameOver()
    {
        moveSpeed = 0;
        aiChaseScript.speed = 0;
        gameOverPanel.SetActive(true);
    }
}
