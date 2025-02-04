using UnityEngine;

public class PoopCollector : MonoBehaviour
{
    public GameObject poop;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Dog")
        {
            Destroy(poop);
        }
    }
}
