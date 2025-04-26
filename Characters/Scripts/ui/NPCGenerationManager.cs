using System.Text;
using Crosstales;
using Crosstales.FB;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;


public class NPCGenerationManager : MonoBehaviour {

    [SerializeField] PersonalityTraitList traitList;
    [SerializeField] PersonalityTraitList interestList;
    [SerializeField] PersonalityTraitList profesionList;
    [SerializeField] PersonalityTraitList backgroundList;

    [SerializeField] TMP_InputField minTraitsField;
    [SerializeField] TMP_InputField maxTraitsField;
    [SerializeField] TMP_InputField minInterestField;
    [SerializeField] TMP_InputField maxInterestField;
    [SerializeField] TMP_InputField proChanceField;
    [SerializeField] TMP_InputField bgChanceField;
    [SerializeField] TMP_InputField bothChanceField;
    [SerializeField] TMP_InputField batchSizeField;
    [SerializeField] GameObject batchSizeUI;
    [SerializeField] Toggle batchModeToggle;

    [SerializeField] TextMeshProUGUI outputText;
    [SerializeField] GameObject[] saveButtons;

    [SerializeField] int minTraits;
    [SerializeField] int maxTraits;
    [SerializeField] int minInterest;
    [SerializeField] int maxInterest;
    [SerializeField] int proChance;
    [SerializeField] int bgChance;
    [SerializeField] int bothChance;
    [SerializeField] int batchSize;

    private bool batchMode = false;

    private Personality personality;

    private StringBuilder[] lastOutput;

    readonly string[] extensions = { "txt" };

    readonly string[] htmlext    = { "html" };


    private void Awake() {
        minTraitsField.text = minTraits.ToString();
        maxTraitsField.text = maxTraits.ToString();
        minInterestField.text = minInterest.ToString();
        maxInterestField.text = maxInterest.ToString();
        proChanceField.text = proChance.ToString();
        bgChanceField.text = bgChance.ToString();
        bothChanceField.text = bothChance.ToString();
        batchSizeField.text = batchSize.ToString();
    }


    private void SetNumtSetting(string number, ref int value, TMP_InputField field) {
        number.Trim();
        int result = value;
        try {
            result = int.Parse(number);
        } catch {
            field.text = value.ToString();
        }
        if(result == Mathf.Clamp(result, 0, 100)) value = result;
        else field.text = value.ToString();
    }


    public  void SetMinTraits(string number) {
        SetNumtSetting(number, ref minTraits, minTraitsField);
        if(minTraits > maxTraits) minTraits = maxTraits;
        minTraitsField.text = minTraits.ToString();
    }

    public  void SetMaxTraits(string number) {
        SetNumtSetting(number, ref maxTraits, maxTraitsField);
        if(maxTraits < minTraits) maxTraits = minTraits;
        maxTraitsField.text = maxTraits.ToString();
    }

    public  void SetMinInterests(string number) {
        SetNumtSetting(number, ref minInterest, minInterestField);
        if(minInterest > maxInterest) minInterest = maxInterest;
        minInterestField.text = minInterest.ToString();
    }

    public  void SetMaxInterests(string number) {
        SetNumtSetting(number, ref maxInterest, maxInterestField);
        if(maxInterest < minInterest) maxInterest = minInterest;
        maxInterestField.text = maxInterest.ToString();
    }

    public  void SetProChance(string number) => SetNumtSetting(number, ref proChance, proChanceField);
    public  void SetBgChance(string number) => SetNumtSetting(number, ref bgChance, bgChanceField);
    public  void SetBothChance(string number) => SetNumtSetting(number, ref bothChance, bothChanceField);

    public  void SetBatchSize(string number) {
        SetNumtSetting(number, ref batchSize, batchSizeField);
        if(batchSize < 1) maxInterest = 1;
        batchSizeField.text = batchSize.ToString();
    }


    public void GenerateCharacter() {
        personality = new Personality(traitList, minTraits, maxTraits);
        personality.AddIntersts(interestList, minInterest, maxInterest);
        if(Random.Range(0, 100) < bothChance) {
            personality.AddProfession(profesionList);
            personality.AddBackground(backgroundList);
        } else {
            if(Random.Range(0, 100) < proChance) {
                personality.AddProfession(profesionList);
            }
            if(Random.Range(0, 100) < bgChance) {
                personality.AddBackground(backgroundList);
            }
        }
        lastOutput = personality.GetResults();
        outputText.text = lastOutput[0].ToString();
    }


    public void GenerateBatchCharacters() {
        lastOutput = new StringBuilder[2];
        lastOutput[0] = new StringBuilder();
        lastOutput[1] = new StringBuilder("******************************************************************************************************");
        lastOutput[1].Append(System.Environment.NewLine);
        for(int i = 0; i < batchSize; i++) {
            lastOutput[1].Append((i + 1) + " ");
            personality = new Personality(traitList, minTraits, maxTraits);
            personality.AddIntersts(interestList, minInterest, maxInterest);
            if(Random.Range(0, 100) < bothChance) {
                personality.AddProfession(profesionList);
                personality.AddBackground(backgroundList);
            } else {
                if(Random.Range(0, 100) < proChance) {
                    personality.AddProfession(profesionList);
                }
                if(Random.Range(0, 100) < bgChance) {
                    personality.AddBackground(backgroundList);
                }
            }
            StringBuilder[] tmp = personality.GetResults();
            lastOutput[0].Append(tmp[0].ToString());
            lastOutput[1].Append(tmp[1].ToString());
            lastOutput[0].Append("<BR>").Append(System.Environment.NewLine);
            lastOutput[1].Append(System.Environment.NewLine)
                        .Append("******************************************************************************************************")
                        .Append(System.Environment.NewLine);

        }
        SaveRstults();
    }


    public void ToggleBatchMode() {
        batchMode = batchModeToggle.isOn;
        batchSizeUI.SetActive(batchMode);
    }


    public void Generate() {
        if(batchMode) {
            GenerateBatchCharacters();
        } else {
            GenerateCharacter();
            saveButtons[0].SetActive(true);
        }
    }


    public void SaveRstults() {
        if((lastOutput == null) || (lastOutput[1] == null) || (lastOutput[1].ToString() == "")) return;
        byte[] data = lastOutput[1].ToString().CTToByteArray();
        FileBrowser.Instance.CurrentSaveFileData = data;
        #if UNITY_STANDALONE_WIN
        string path = FileBrowser.Instance.SaveFile("Save Inspiration",
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "CharacterIdea", extensions);
        #else
        string path = FileBrowser.Instance.SaveFile("Save Inspiration",
                System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile),
                "CharacterIdea", extensions);
        #endif
}


    public void Quit() {
        Application.Quit();
    }



}
