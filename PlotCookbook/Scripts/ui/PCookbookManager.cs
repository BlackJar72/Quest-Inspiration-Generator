using TMPro;
using UnityEngine;
using Crosstales;
using Crosstales.FB;

public class PCookbookManager : MonoBehaviour
{
    [SerializeField] PlotElementGenerator[] generators;
    [SerializeField] TextMeshProUGUI outputText;

    private int generatorSelected = 0;
    private string[] lastOutput;

    readonly string[] extensions = { "txt" };


    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void SetGenerator(int which) {
        generatorSelected = which;
    }


    public void Generate() {
        lastOutput = generators[generatorSelected].Roll();
        #if UNITY_EDITOR
        Debug.Log(lastOutput);
        #endif
        //TODO: Normal output forms
        outputText.SetText(lastOutput[0]);
    }


    public void ExitApp() {
        Application.Quit();
    }


    public void SaveRstults() {
        byte[] data = lastOutput[1].CTToByteArray();
        FileBrowser.Instance.CurrentSaveFileData = data;
        string path = FileBrowser.Instance.SaveFile("Save Inspiration", "",
                "PlotIdea", extensions);
    }


}
