using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public partial class GoldProductionUnitScript : MonoBehaviour {
    public GoldProductionUnit goldProductionUnit;
    public Text goldAmountText;
    public Text purchaseButtonLabel;
    private Gold gold;
    

    public int GoldPressAmount {
        get => PlayerPrefs.GetInt(this.goldProductionUnit.name, 0);
        set {
            PlayerPrefs.SetInt(this.goldProductionUnit.name, value);
            UpdateGoldPressAmountLabel();
        }
    }
    void UpdateGoldPressAmountLabel() {
        this.goldAmountText.text = this.GoldPressAmount.ToString($"0 {this.goldProductionUnit.name}");
    }

   
    public void SetUp(GoldProductionUnit goldProductionUnit) {
        this.goldProductionUnit = goldProductionUnit;
        this.gameObject.name = goldProductionUnit.name;
        this.purchaseButtonLabel.text = $"Purchase {goldProductionUnit.name}";
    }


    void Start() {
        gold = FindObjectOfType<Gold>();
        StartCoroutine(StartProducing());
        UpdateGoldPressAmountLabel();
    }

    public void BuyGoldPess() {
        if (gold.GoldAmount >= this.goldProductionUnit.cost) {
            gold.ReduceGold(this.goldProductionUnit.cost);
            this.GoldPressAmount++;
        }
    }

    IEnumerator StartProducing() {
        while (true) {
            yield return new WaitForSeconds(1);
            ProduceGold();
        }
    }

    void ProduceGold() {
        var goldPerSecond = this.goldProductionUnit.productionAmount * this.GoldPressAmount;
        gold.AddGold(goldPerSecond);
    }
}