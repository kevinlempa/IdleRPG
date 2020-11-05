using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public partial class ResourceProducer : MonoBehaviour {
    public GoldProductionData goldProductionData;
    public Text upgradeAmountText;
    public Text AmountText;
    public Resource gold;
    public Text floatingText;
    public Purchasable amount;
    public Purchasable upgrade;

    
    public void Purchase() {
        this.amount.Purchase();
    }

    public void Upgrade() {
        this.upgrade.Purchase();
    }

    void UpdateAmountLabels() {
        this.upgradeAmountText.text = this.upgrade.Amount.ToString($" 0 Upgrades");
        this.AmountText.text = this.amount.Amount.ToString($"0 {this.goldProductionData.name}");
    }


    public void SetUp(GoldProductionData goldProductionData) {
        this.goldProductionData = goldProductionData;
        this.gameObject.name = goldProductionData.name;
        this.amount.SetUp(goldProductionData, this.gold, "Count", this.goldProductionData.cost);
        this.upgrade.SetUp(goldProductionData, this.gold, "Level", this.goldProductionData.upgradeCost);
    }

    private void Update() {
        
    }


    void Start() {
        StartCoroutine(StartProducing());
        UpdateAmountLabels();
        this.upgrade.AmountChanged += UpdateAmountLabels;
        this.amount.AmountChanged += UpdateAmountLabels;
    }
    
    IEnumerator StartProducing() {
        while (true) {
            yield return new WaitForSeconds(goldProductionData.productionTime);
            ProduceGold();
        }
    }

    void ProduceGold() {
        if (this.amount.Amount == 0)
            return;
        var goldPerSecond = Mathf.RoundToInt(this.goldProductionData.productionAmount * this.amount.Amount *
                                             Mathf.Pow(goldProductionData.upgradePercantage, this.upgrade.Amount));
        gold.AddResource(goldPerSecond);
        var instance = Instantiate(floatingText, transform);
        instance.text = $"+{goldPerSecond}";
    }
}