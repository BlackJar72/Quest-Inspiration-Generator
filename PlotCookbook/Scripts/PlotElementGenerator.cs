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

    public string[] Roll() {
        string[] output = new string[2];
        StringBuilder results   = new StringBuilder(Environment.NewLine + "<B><U>" + header + "</U></B>" + Environment.NewLine);
        StringBuilder resultsUF = new StringBuilder(Environment.NewLine + header + Environment.NewLine);
        for(int i = 0; i < tables.Count; i++) {
            string[] next = tables[i].Roll();
            results.Append(next[0]);
            resultsUF.Append(next[1]);
        }
        results.Append(Environment.NewLine);
        resultsUF.Append(Environment.NewLine);
        output[0] =  results.ToString();
        output[1] = resultsUF.ToString();
        return output;
    }


}
