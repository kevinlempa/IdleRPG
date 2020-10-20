using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPress : MonoBehaviour {
    public int goldPressOwned;
    public int productionCost;
    public int goldPerSecondPerPress;
    private Gold gold;

    void Start() {
        gold = FindObjectOfType<Gold>();
        StartCoroutine(StartPrinting());
    }

    public void BuyGoldPess() {
        if (gold.GoldAmount > productionCost) {
            gold.ReduceGold(productionCost);
            goldPressOwned++;
        }
    }

    IEnumerator StartPrinting() {
        while (true) {
            yield return new WaitForSeconds(1f);
            PrintMoney();
        }
    }

    void PrintMoney() {
        var goldPerSecond = goldPerSecondPerPress * goldPressOwned;
        gold.AddGold(goldPerSecond);
    }
}