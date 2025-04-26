using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif



[System.Serializable]
[CreateAssetMenu(menuName = "KF Tools/NPC Roller/Trait Table", fileName = "TraitTable", order = 102)]
public class PersonalityTraitList : ScriptableObject {

    [SerializeField] PersonalityTraitList earlierList;
    [SerializeField] List<PersonalityTrait> data;


#if UNITY_EDITOR
    void Awake()
    {
        Init();
    } 


    [ContextMenu("Initialize")]
    public void Init() {
        data?.Sort();
    }
#endif


    public List<PersonalityTrait> RollTraits(CorePersonality core, int min, int max) {
        int num = min;
        if(max > min) num = Random.Range(min, max + 1);
        List<PersonalityTrait> available = new();
        foreach(PersonalityTrait t in data) {
            if(core.IsCompatible(t)) available.Add(t);
        }
        if(earlierList != null) foreach(PersonalityTrait trait in earlierList.data) {
            foreach(PersonalityTrait conficting in earlierList.data) available.Remove(conficting);
        }
        List<PersonalityTrait> result = new();
        for(int i = 0; i < num; i++) {
            int roll = Random.Range(0, available.Count);
            result.Add(available[roll]);
            available.RemoveAt(roll);
            foreach(PersonalityTrait conflicting in result[i].Conflicting) available.Remove(conflicting);
            if(available.Count < 1) break;
        }
        return result;
    }


    public List<PersonalityTrait> RollTraitOrTwo(CorePersonality core) {
        List<PersonalityTrait> available = new();
        foreach(PersonalityTrait t in data) {
            if(core.IsCompatible(t)) available.Add(t);
        }
        if(earlierList != null) foreach(PersonalityTrait trait in earlierList.data) {
            foreach(PersonalityTrait conficting in earlierList.data) available.Remove(conficting);
        }
        List<PersonalityTrait> result = new();
        if(available.Count > 0) {
            int roll = Random.Range(0, available.Count);
            result.Add(available[roll]);
            available.RemoveAt(roll);
            foreach(PersonalityTrait conflicting in result[0].Conflicting) available.Remove(conflicting);
        }
        if((available.Count > 0) && (Random.Range(0, 100) < 10)) {
            int roll = Random.Range(0, available.Count);
            result.Add(available[roll]);
            available.RemoveAt(roll);
            foreach(PersonalityTrait conflicting in result[1].Conflicting) available.Remove(conflicting);
        }
        return result;
    }



}
