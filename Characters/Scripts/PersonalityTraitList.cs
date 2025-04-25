using System.Collections.Generic;
using UnityEditor;

#if UNITY_EDITOR
using UnityEngine;
using UnityEngine.InputSystem.Interactions;
#endif



[System.Serializable]
[CreateAssetMenu(menuName = "KF Tools/NPC Roller/Trait Table", fileName = "TraitTable", order = 102)]
public class PersonalityTraitList : ScriptableObject {

    [SerializeField] List<PersonalityTrait> data;


    void Awake()
    {
        Init();
    } 


    [ContextMenu("Initialize")]
    public void Init() {
        data.Sort();
    }


    public List<PersonalityTrait> RollTraits(CorePersonality core, int min, int max) {
        int num = min;
        if(max > min) num = Random.Range(min, max + 1);
        List<PersonalityTrait> available = new();
        foreach(PersonalityTrait t in data) {
            if(core.IsCompatible(t)) available.Add(t);
        }
        List<PersonalityTrait> result = new();
        for(int i = 0; i < num; i++) {
            int roll = Random.Range(0, available.Count);
            result[i] = available[roll];
            available.RemoveAt(roll);
            foreach(PersonalityTrait conflicting in result[i].Conflicting) available.Remove(conflicting);
            if(available.Count < 1) break;
        }
        return result;

    }



}
