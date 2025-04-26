using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


[System.Serializable]
public class Personality {

    const string header = "Character";

    CorePersonality corePersonality;
    List<PersonalityTrait> traits;
    List<PersonalityTrait> interests;
    List<PersonalityTrait> profession;
    List<PersonalityTrait> background;


    public List<PersonalityTrait> Traits => traits;
    public List<PersonalityTrait> Interests => interests;
    public List<PersonalityTrait> Profesion => profession;
    public List<PersonalityTrait> Background => background;


    public Personality(PersonalityTraitList traitList, int minTraits, int maxTraits) {
        corePersonality = new();
        traits = traitList.RollTraits(corePersonality, minTraits, maxTraits);
    }


    public void AddIntersts(PersonalityTraitList interestList, int min, int max) {
        interests = interestList.RollTraits(corePersonality, min, max);
    }


    public void AddProfession(PersonalityTraitList professionList) {
        profession = professionList.RollTraitOrTwo(corePersonality);
    }


    public void AddBackground(PersonalityTraitList backgroundList) {
        background = backgroundList.RollTraitOrTwo(corePersonality);
    }


    public StringBuilder[] GetResults() {
        StringBuilder[] output = new StringBuilder[2];
        StringBuilder results   = new StringBuilder(Environment.NewLine + "<B><U>" + header + "</U></B><BR>" + Environment.NewLine);
        StringBuilder resultsUF = new StringBuilder(Environment.NewLine + header + Environment.NewLine + Environment.NewLine);
        GetStringFromCoreTraits(results, resultsUF);
        if((traits != null) && (traits.Count > 0)) GetStringFromTraits(results, resultsUF, traits, "Traits");
        if((interests != null) && (interests.Count > 0)) GetStringFromTraits(results, resultsUF, interests, "Interests");
        if((profession != null) && (profession.Count > 0)) GetStringFromTraits(results, resultsUF, profession, "Profession");
        if((background != null) && (background.Count > 0)) GetStringFromTraits(results, resultsUF, background, "Background");
        results.Append(Environment.NewLine);
        resultsUF.Append(Environment.NewLine);
        output[0] =  results;
        output[1] = resultsUF;
        return output;
    }


    private void GetStringFromTraits(StringBuilder results, StringBuilder resultsUF, List<PersonalityTrait> traits, string label) {
        results.Append("<B>" + label + ":</B> ");
        resultsUF.Append(label + ": ");
        for(int i = 0; i < traits.Count; i++) {
            if (i > 0) {
                results.Append("; ");
                resultsUF.Append("; ");
            }
            results.Append(traits[i].Description);
            resultsUF.Append(traits[i].Description);
        }
        results.Append("<BR>").Append(Environment.NewLine);
        resultsUF.Append(Environment.NewLine).Append(Environment.NewLine);
    }


    private void GetStringFromCoreTraits(StringBuilder results, StringBuilder resultsUF) {
        results.Append("<B>Core Traits:</B> ");
        resultsUF.Append("Core Traits: ");
        results.Append("Openess=" + corePersonality.O +  "; ");
        resultsUF.Append("Openess=" + corePersonality.O +  "; ");
        results.Append("Concientiousness=" + corePersonality.C +  "; ");
        resultsUF.Append("Concientiousness=" + corePersonality.C +  "; ");
        results.Append("Extroversion=" + corePersonality.E +  "; ");
        resultsUF.Append("Extroversion=" + corePersonality.E +  "; ");
        results.Append("Agreeableness=" + corePersonality.A +  "; ");
        resultsUF.Append("Agreeableness=" + corePersonality.A +  "; ");
        results.Append("Neuroticism=" + corePersonality.N +  "; ");
        resultsUF.Append("Neuroticism=" + corePersonality.N +  "; ");
        results.Append("<BR>").Append(Environment.NewLine);
        resultsUF.Append(Environment.NewLine).Append(Environment.NewLine);
    }





}
