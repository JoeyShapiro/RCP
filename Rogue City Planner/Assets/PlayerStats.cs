using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 400;

    public Text MoneyText;

    void Start() {
        Money = startMoney;
    }

    void Update() {
        MoneyText.text = "$" + Money.ToString();
    }
}
