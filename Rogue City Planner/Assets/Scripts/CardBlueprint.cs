using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardBlueprint
{
    public GameObject prefab;
    public int cost;
    public string name;
    public string description;
    public bool phase; // true is day
    public string hero;
    public int rarity; // do we want this
    // maybe action

    public CardBlueprint() {

    }
}
