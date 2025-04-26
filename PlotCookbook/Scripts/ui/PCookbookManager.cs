using System;
using Crosstales;
using Crosstales.FB;
using TMPro;
using UnityEngine;


public class PCookbookManager : MonoBehaviour {
    [SerializeField] PlotElementGenerator[] generators;
    [SerializeField] TextMeshProUGUI outputText;
    [SerializeField] GameObject[] saveButtons;

    private int generatorSelected = 0;
    private string[] lastOutput;

    readonly string[] extensions = { "txt" };

    readonly string[] htmlext    = { "html" };


    public void SetGenerator(int which) {
        generatorSelected = which;
    }


    public void Generate() {
        lastOutput = generators[generatorSelected].Roll();
        saveButtons[0].SetActive(true);
        #if UNITY_EDITOR
        #endif
        //TODO: Normal output forms
        outputText.SetText(lastOutput[0]);
    }


    public void ExitApp() {
        Application.Quit();
    }


    public void SaveRstults() {
        if((lastOutput == null) || (lastOutput[1] == null) || (lastOutput[1] == "")) return;
        byte[] data = lastOutput[1].CTToByteArray();
        FileBrowser.Instance.CurrentSaveFileData = data;
        #if UNITY_STANDALONE_WIN
        string path = FileBrowser.Instance.SaveFile("Save Inspiration",
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "PlotIdea", extensions);
        #else
        string path = FileBrowser.Instance.SaveFile("Save Inspiration",
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                "PlotIdea", extensions);
        #endif
}


public void SaveRstultsHTML() {/*
    if((lastOutput == null) || (lastOutput[0] == null) || (lastOutput[0] == "")) return;
    string page = "<HTML><HEADER></HEADER><BODY>" + lastOutput[0] + "</BODY></HTML>";
    byte[] data = page.CTToByteArray();
    FileBrowser.Instance.CurrentSaveFileData = data;
    string path = FileBrowser.Instance.SaveFile("Save Inspiration", "",
            "PlotIdea", htmlext);
*/}


}
