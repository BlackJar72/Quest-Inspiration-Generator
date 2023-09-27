using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlotElement
{
    [SerializeField] Table table;
    [SerializeField] int minInstances = 1;
    [SerializeField] int maxInstances = 1;
    [SerializeField] bool canBeZero = false;
    [SerializeField] bool allowDuplicates = true;

    private HashSet<string> used = new HashSet<string>();

    public string[] Roll() {
        string[] output = new string[2];
        int num;
        if(maxInstances > minInstances) num = UnityEngine.Random.Range(minInstances, maxInstances + 1);
        else num = minInstances;
        if(!canBeZero) num = Mathf.Max(1, num);
        if(num < 1) {
            output[0] = output[1] = "";
            return output;
        }
        used.Clear();
        StringBuilder results = new StringBuilder("<B>" + table.Name + ":</B> ");
        StringBuilder resultsUF = new StringBuilder(table.Name + ": ");
        for(int i = 0; i < num; i++) {
            string result = table.Roll();
            if(allowDuplicates || !used.Contains(result)) {
                if (i > 0) {
                    results.Append("; ");
                    resultsUF.Append("; ");
                }
                results.Append(result);
                resultsUF.Append(result);
                used.Add(result);
            }
        }
        results.Append(Environment.NewLine);
        resultsUF.Append(Environment.NewLine);
        output[0] = results.ToString();
        output[1] = resultsUF.ToString();
        return output;
    }
}
