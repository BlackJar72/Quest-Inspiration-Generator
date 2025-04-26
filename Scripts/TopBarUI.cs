using UnityEngine;

public class TopBarUI : MonoBehaviour {

    [SerializeField] GameObject questPanel;
    [SerializeField] GameObject characterPanel;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        questPanel.SetActive(true);
        characterPanel.SetActive(false);
    }


    public void SetQuestMode() {
        questPanel.SetActive(true);
        characterPanel.SetActive(false);
    }


    public void SetCharacterMode() {
        questPanel.SetActive(false);
        characterPanel.SetActive(true);
    }


    public void Quit() {
        Application.Quit();
    }



}
