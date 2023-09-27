using TMPro;
using UnityEngine;

public class PCookbookManager : MonoBehaviour
{
    [SerializeField] PlotElementGenerator[] generators;
    [SerializeField] TextMeshProUGUI outputText;

    private int generatorSelected = 0;
    private string lastOutput;


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
        outputText.SetText(lastOutput);
    }


    public void ExitApp() {
        Application.Quit();
    }


    public void Print() {
        if((lastOutput == null) || (lastOutput.Length < 1)) return;

    }


}
