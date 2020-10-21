using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public partial class GoldPress : MonoBehaviour, IPurchasableProduct {

    public int goldPressOwned;
    public int productionCost;
    public int goldPerSecondPerPress;
    private Gold gold;
    [SerializeField] private int productionTime;
    private string name;

    public string Name {
        get => name;
        set => name = value;
    }

    public int Cost {
        get => productionCost;
        set => productionCost = value;
    }

    public int ProductionTime {
        get => productionTime;
        set => productionTime = value;
    }

    public int ProductionAmount { get => goldPerSecondPerPress; set => goldPerSecondPerPress = value; }

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