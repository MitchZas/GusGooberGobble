using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System;
using System.Collections;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] CardShowUI cardShowScript;
    [SerializeField] DroppingsManager dm;
    public void OnPointerDown (PointerEventData eventData)
    {
        if (gameObject.tag == "Card")
        {
            Debug.Log("Card activated!");
            cardShowScript.DisableCardShow();
        }
    }
}
