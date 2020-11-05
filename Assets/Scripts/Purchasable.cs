using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Purchasable {
    public Text buttonLabel;
    GoldProductionData goldProductionData;
    Resource gold;
    string productId;
    public event System.Action AmountChanged;
    public int cost;

    public int Amount {
        get => PlayerPrefs.GetInt(this.goldProductionData.name + productId, 0);
        set {
            PlayerPrefs.SetInt(this.goldProductionData.name + productId, value);
            AmountChanged?.Invoke();
        }
    }

    bool IsAffordable => gold.ResourceAmount >= this.goldProductionData.GetActualCosts(this.Amount,cost);
    
    public void SetUp(GoldProductionData goldProductionData, Resource gold, string productId, int cost) {
        gold.ResourceChanged += UpdateTextColor;
        this.goldProductionData = goldProductionData;
        this.gold = gold;
        this.productId = productId;
        this.cost = cost;
        this.buttonLabel.text = $"Add {productId} for {goldProductionData.GetActualCosts(this.Amount,this.cost)}";
    }

    void UpdateTextColor() => this.buttonLabel.color = this.IsAffordable ? Color.black : Color.red;

    public void Purchase() {
        if (this.IsAffordable) {
            gold.ReduceResource(this.goldProductionData.GetActualCosts(this.Amount, this.cost));
            this.Amount++;
            this.buttonLabel.text = $"Purchase for {this.goldProductionData.GetActualCosts(this.Amount, this.cost)}";
            
        }
    }
}


