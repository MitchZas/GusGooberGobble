using UnityEngine;

public class CardShowUI : MonoBehaviour
{
    public GameObject cardShowUI;
    //public GameManager gamemanagerScript;

    public void EnableCardShow()
    {
        cardShowUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void DisableCardShow()
    {
        Debug.Log("Close Card");
        cardShowUI.SetActive(false);
        Time.timeScale = 1f;
    }
}
