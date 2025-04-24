using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Personality {

    CorePersonality corePersonality;
    List<PersonalityTrait> traits;


    public Personality(PersonalityTraitList traitList, int minTraits, int maxTraits) {
        corePersonality = new();
        traits = traitList.RollTraits(corePersonality, minTraits, maxTraits);
    }

}
