using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Personality {

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


    public void AddProfession(PersonalityTraitList professionList, int min, int max) {
        interests = professionList.RollTraits(corePersonality, min, max);
    }


    public void AddBackground(PersonalityTraitList backgroundList, int min, int max) {
        interests = backgroundList.RollTraits(corePersonality, min, max);
    }





}
