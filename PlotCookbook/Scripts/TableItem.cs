using System;
using UnityEngine;

[System.Serializable]
public struct TableItem : IComparable<TableItem>
{

    [SerializeField] public string description;
    [SerializeField] public int cutoff;

    public bool IsFound(int roll) => roll < cutoff;


    public int CompareTo(TableItem other) {
        return cutoff - other.cutoff;
    }
}
