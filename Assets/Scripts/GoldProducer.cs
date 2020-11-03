using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public partial class GoldProducer : MonoBehaviour {
    public GoldProductionData goldProductionData;
    public Text goldAmountText;
    public Text purchaseButtonLabel;
    private Gold gold;
    

    public int Amount {
        get => PlayerPrefs.GetInt(this.goldProductionData.name, 0);
        set {
            PlayerPrefs.SetInt(this.goldProductionData.name, value);
            UpdateGoldPressAmountLabel();
        }
    }
    bool IsAffordable => FindObjectOfType<Gold>().GoldAmount >= this.goldProductionData.cost;
    void UpdateGoldPressAmountLabel() {
        this.goldAmountText.text = this.Amount.ToString($"0 {this.goldProductionData.name}");
    }

   
    public void SetUp(GoldProductionData goldProductionData) {
        this.goldProductionData = goldProductionData;
        this.gameObject.name = goldProductionData.name;
        this.purchaseButtonLabel.text = $"Purchase for {goldProductionData.cost}";
    }


    void Start() {
        gold = FindObjectOfType<Gold>();
        StartCoroutine(StartProducing());
        UpdateGoldPressAmountLabel();
    }

    public void BuyGoldPess() {
        if (gold.GoldAmount >= this.goldProductionData.cost) {
            gold.ReduceGold(this.goldProductionData.cost);
            this.Amount++;
        }
    }

    IEnumerator StartProducing() {
        while (true) {
            yield return new WaitForSeconds(1);
            ProduceGold();
        }
    }

    void ProduceGold() {
        var goldPerSecond = this.goldProductionData.productionAmount * this.Amount;
        gold.AddGold(goldPerSecond);
    }
}