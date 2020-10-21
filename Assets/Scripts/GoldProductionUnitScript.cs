using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public partial class GoldProductionUnitScript : MonoBehaviour {
    public GoldProductionUnit goldProductionUnit;
    public Text purchaseButtonLabel;
    private int productionUnitAmount;
    private Gold gold;


    public void SetUp(GoldProductionUnit goldProductionUnit) {
        this.goldProductionUnit = goldProductionUnit;
        this.gameObject.name = goldProductionUnit.name;
        this.purchaseButtonLabel.text = $"Purchase {goldProductionUnit.name}";
    }


    void Start() {
        gold = FindObjectOfType<Gold>();
        StartCoroutine(StartProducing());
    }

    public void BuyGoldPess() {
        if (gold.GoldAmount >= goldProductionUnit.cost) {
            gold.ReduceGold(goldProductionUnit.cost);
            productionUnitAmount++;
        }
    }

    IEnumerator StartProducing() {
        while (true) {
            yield return new WaitForSeconds(1);
            ProduceGold();
        }
    }

    void ProduceGold() {
        var goldPerSecond = goldProductionUnit.productionAmount * productionUnitAmount;
        gold.AddGold(goldPerSecond);
    }
}