using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System;
using System.Collections;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] CardShowUI cardShowScript;
    public void OnPointerDown (PointerEventData eventData)
    {
        if (gameObject.tag == "Card")
        {
            // Set the CardShow Game Object to false
            cardShowScript.DisableCardShow();
            // Add the Zoomies Ability
            Debug.Log("Card activated!");
        }
    }
}
