using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [Header("Day Phase")]
    public CardBlueprint factory;
    public CardBlueprint farm;
    public CardBlueprint mine;
    public CardBlueprint blacksmith;
    public CardBlueprint fishery;
    public CardBlueprint reactor; // change name or something
    public CardBlueprint refinery;
    public CardBlueprint windmill;
    
    [Header("Night Cycle")]
    public CardBlueprint smite;
}
