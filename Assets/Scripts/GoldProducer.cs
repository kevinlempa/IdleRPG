using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public partial class GoldProducer : MonoBehaviour {
    public GoldProductionData goldProductionData;
    public Text upgradeAmountText;
    public Text goldAmountText;
    public Text purchaseButtonLabel;
    public Text upgradeButtonLabel;
    private Gold gold;
    public Text floatingText;

    public int UpgradeAmount {
        get => PlayerPrefs.GetInt(this.goldProductionData.name + "UpgradeAmount", 0);
        set {
            PlayerPrefs.SetInt(this.goldProductionData.name + "UpgradeAmount", value);
            UpdateAmountLabels();
        }
    }

    public int Amount {
        get => PlayerPrefs.GetInt(this.goldProductionData.name + "Amount", 0);
        set {
            PlayerPrefs.SetInt(this.goldProductionData.name + "Amount", value);
            UpdateAmountLabels();
        }
    }

    bool IsAffordable => gold.GoldAmount >= this.goldProductionData.GetActualCosts(this.Amount);
    bool IsAffordableUpgrade => gold.GoldAmount >= this.goldProductionData.GetUpgradeCost(this.UpgradeAmount);

    void UpdateAmountLabels() {
        this.upgradeAmountText.text = this.UpgradeAmount.ToString($" 0 Upgrades");
        this.goldAmountText.text = this.Amount.ToString($"0 {this.goldProductionData.name}");
    }


    public void SetUp(GoldProductionData goldProductionData) {
        this.goldProductionData = goldProductionData;
        this.gameObject.name = goldProductionData.name;
        this.purchaseButtonLabel.text = $"Purchase for {goldProductionData.GetActualCosts(this.Amount)}";
        this.upgradeButtonLabel.text = $"Purchase for {this.goldProductionData.GetUpgradeCost(this.UpgradeAmount)}";
    }

    private void Update() {
        UpdateTextColor();
    }


    void Start() {
        gold = FindObjectOfType<Gold>();
        StartCoroutine(StartProducing());
        UpdateAmountLabels();
    }

    void UpdateTextColor() {
        this.purchaseButtonLabel.color = this.IsAffordable ? Color.black : Color.red;
        this.upgradeButtonLabel.color = this.IsAffordableUpgrade ? Color.black : Color.red;
    }

    public void Purchase() {
        if (this.IsAffordable) {
            gold.ReduceGold(this.goldProductionData.GetActualCosts(this.Amount));
            this.Amount++;
            this.purchaseButtonLabel.text = $"Purchase for {this.goldProductionData.GetActualCosts(this.Amount)}";
        }
    }

    public void PurchaseUpgrade() {
        if (this.IsAffordableUpgrade) {
            gold.ReduceGold(this.goldProductionData.GetUpgradeCost(this.UpgradeAmount));
            this.UpgradeAmount++;
            this.upgradeButtonLabel.text = $"Purchase for {this.goldProductionData.GetUpgradeCost(this.UpgradeAmount)}";
        }
    }

    IEnumerator StartProducing() {
        while (true) {
            yield return new WaitForSeconds(goldProductionData.productionTime);
            ProduceGold();
        }
    }

    void ProduceGold() {
        if (this.Amount == 0)
            return;
        var goldPerSecond = Mathf.RoundToInt(this.goldProductionData.productionAmount * this.Amount *
                                             Mathf.Pow(goldProductionData.upgradePercantage, this.UpgradeAmount));
        ;
        gold.AddGold(goldPerSecond);
        var instance = Instantiate(floatingText, transform);
        instance.text = $"+{goldPerSecond}";
    }
}