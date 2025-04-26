using Crosstales;
using Crosstales.FB;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;


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
    [SerializeField] TMP_InputField narrativeChanceField;

    [SerializeField] TextMeshProUGUI outputText;
    [SerializeField] GameObject[] saveButtons;

    [SerializeField] int minTraits;
    [SerializeField] int maxTraits;
    [SerializeField] int minInterest;
    [SerializeField] int maxInterest;
    [SerializeField] int proChance;
    [SerializeField] int bgChance;
    [SerializeField] int bothChance;
    [SerializeField] int narrativeChance;

    private Personality personality;

    private string[] lastOutput;

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
        narrativeChanceField.text = narrativeChance.ToString();
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
    public  void SetNarrativeChance(string number) => SetNumtSetting(number, ref narrativeChance, narrativeChanceField);


    public void GenerateCharacter() {
        personality = new Personality(traitList, minTraits, maxTraits);
        if(bothChance < Random.Range(0, 100)) {
            if(Random.Range(0, 5) == 0) personality.AddProfession(profesionList, 1,2);
            else personality.AddProfession(profesionList, 1, 1);
            if(Random.Range(0, 2) == 0) personality.AddProfession(profesionList, 1,2);
            else personality.AddProfession(profesionList, 1, 1);
        } else {
            if(proChance < Random.Range(0, 100)) {
                if(Random.Range(0, 5) == 0) personality.AddProfession(profesionList, 1,2);
                else personality.AddProfession(profesionList, 1, 1);
            }
            if(bgChance < Random.Range(0, 100)) {
                if(Random.Range(0, 2) == 0) personality.AddProfession(profesionList, 1,2);
                else personality.AddProfession(profesionList, 1, 1);
            }
        }
        if(narrativeChance < Random.Range(0, 100)) {
            // TODO!!!
        }
    }


    public void Generate() {
        GenerateCharacter();
        // TODO: Generate Text
    }



}
