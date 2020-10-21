using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public partial class GoldPress : MonoBehaviour {

    public int goldPressAmount;
    public int cost;
    public int productionAmount;
    private Gold gold;
    private float productionTime = 1f;
    private string name = "GoldPress";



    void Start() {
        gold = FindObjectOfType<Gold>();
        StartCoroutine(StartProducing());
    }

    public void BuyGoldPess() {
        if (gold.GoldAmount > cost) {
            gold.ReduceGold(cost);
            goldPressAmount++;
        }
    }

    IEnumerator StartProducing() {
        while (true) {
            yield return new WaitForSeconds(productionTime);
            ProduceGold();
        }
    }

    void ProduceGold() {
        var goldPerSecond = productionAmount * goldPressAmount;
        gold.AddGold(goldPerSecond);
    }
}