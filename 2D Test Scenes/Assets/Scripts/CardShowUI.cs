using UnityEngine;

public class CardShowUI : MonoBehaviour
{
    public GameObject cardShowUI;
    public GameObject cardshowPanel;
    public GameManager gamemanagerScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cardShowUI.SetActive(false);
    }

    public void EnableCardShow()
    {
        cardShowUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void DisableCardShow()
    {
        //cardShowUI.SetActive(false);
        cardshowPanel.SetActive(false);
        Debug.Log("Normal Speed");
        gamemanagerScript.ResumeGame();
    }
}
