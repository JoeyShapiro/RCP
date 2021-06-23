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

    public Text HealthText;

    public static int Energy;
    public int maxEnergy = 3;

    public Text EnergyText;

    public static int Draw;
    public int maxDraw = 6;

    public Text DrawText;

    void Start() {
        Money = startMoney;
        Health = maxHealth;
    }

    void Update() {
        MoneyText.text = "$" + Money.ToString();
        HealthText.text = "Health: " + Health.ToString();
    }
}
