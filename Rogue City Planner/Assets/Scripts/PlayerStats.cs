using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 400;

    public Text MoneyText;

    public static int Health;
    public int maxHealth = 100;

    void Start() {
        Money = startMoney;
        Health = maxHealth;
    }

    void Update() {
        MoneyText.text = "$" + Money.ToString();
    }
}
