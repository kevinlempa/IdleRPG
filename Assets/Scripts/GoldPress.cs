using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPress : MonoBehaviour {
    [SerializeField] private int goldPressOwned;
    [SerializeField] private int productionCost;
    [SerializeField] private int goldPerSecondPerPress;
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

    // Update is called once per frame
    void Update() {
    }
}