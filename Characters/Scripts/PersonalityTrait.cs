using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "KF Tools/NPC Roller/Character Trait", fileName = "Trait", order = 101)]
public class PersonalityTrait : ScriptableObject, System.IComparable<PersonalityTrait> {

    [System.Serializable]
    public struct Requiremnt {
        [SerializeField] CorePersonality.CoreTraits trait;
        [SerializeField] int value;
        [SerializeField] bool lessThan;
        public readonly CorePersonality.CoreTraits Trait => trait;
        public readonly int Value => value;
        public readonly bool LessThan => lessThan;
    }

    [SerializeField] string description;
    [SerializeField] Requiremnt[] requiremnt;
    [SerializeField] List<PersonalityTrait> conflicting;


    public string Description => description;
    public Requiremnt[] Reqs => requiremnt;
    public List<PersonalityTrait> Conflicting => conflicting;


    public int CompareTo(PersonalityTrait other) {
        return string.Compare(description, other.description);
    }


    


    
}
