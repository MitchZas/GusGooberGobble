using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PoopCollector : MonoBehaviour
{
    public GameObject poop;

    public int droppingsValue;

    private void Start()
    {
        droppingsValue = 0;
        Debug.Log(droppingsValue);
    }

    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.gameObject.tag == "Dog")
    //    {
    //        droppingsValue += 1;
    //        Debug.Log(droppingsValue);
    //        poop.SetActive(false);
    //    }
    //}
}
