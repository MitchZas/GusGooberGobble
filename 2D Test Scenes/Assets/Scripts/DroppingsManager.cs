using JetBrains.Annotations;
using UnityEngine;

public class DroppingsManager : MonoBehaviour
{
    public int droppingsCount;
    public int digRate;

    public GameObject[] droppings;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        droppings[0].SetActive(true);
        droppings[1].SetActive(true);
        droppings[2].SetActive(true);
        droppings[3].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
   
    }
}
