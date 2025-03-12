using UnityEngine;
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

    public ContactFilter2D contactFilter;

    [SerializeField] DroppingsManager dm;
    [SerializeField] CardShowUI cardShowScript;

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

        if (dm.digRate == 3)
        {
            cardShowScript.EnableCardShow();
        }

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position,Vector2.down);

            if (hit.collider.CompareTag("Dirt"))
            {
                Debug.Log("Digging Started");
                dirtDig.Play();
                dm.digRate++;
                // Sprite goes away  
                // Show two items 
                // Have the player pick between two items 
                // Equip item chosen
            }

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
