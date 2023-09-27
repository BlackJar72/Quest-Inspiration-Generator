using System.Collections;
using System;
using System.Text;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "KF Tools/Table Roller/Plot Generator", fileName = "Generator", order = 003)]
public class PlotElementGenerator : ScriptableObject
{
    [SerializeField] string header;
    [SerializeField] List<PlotElement> tables;

    public string Roll() {
        StringBuilder results = new StringBuilder(Environment.NewLine + "<B><U>" + header + "</U></B>" + Environment.NewLine);
        for(int i = 0; i < tables.Count; i++) {
            results.Append(tables[i].Roll());
        }
        results.Append(Environment.NewLine);
        return results.ToString();
    }


}
