using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "KF Tools/Table Roller/Table", fileName = "Table", order = 002)]
public class Table : ScriptableObject
{
    [SerializeField] string tableName;
    [SerializeField] int die;
    [SerializeField] List<TableItem> data;

    public string Name { get => tableName; }

    void Start() => Init();

    public void Init() {
        data.Sort();
    }

    public string Roll() {
        int roll = Random.Range(0, die) + 1;
        for(int i = 0; i < data.Count; i++) {
            if(data[i].IsFound(roll)) return data[i].description;
        }
        return data[data.Count - 1].description;
    }


}
