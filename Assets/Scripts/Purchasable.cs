using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Purchasable {
    public Text buttonLabel;
    ResourceProductionData _resourceProductionData;
    string productId;
    public event System.Action AmountChanged;
    public int cost;

    public int Amount {
        get => PlayerPrefs.GetInt(this._resourceProductionData.name + productId, 0);
        set {
            PlayerPrefs.SetInt(this._resourceProductionData.name + productId, value);
            AmountChanged?.Invoke();
        }
    }

    bool IsAffordable => _resourceProductionData.costResource.ResourceAmount >= this._resourceProductionData.GetActualCosts(this.Amount,cost);
    
    public void SetUp(ResourceProductionData resourceProductionData, Resource gold, string productId, int cost) {
        gold.ResourceChanged += UpdateTextColor;
        this._resourceProductionData = resourceProductionData;
        this.productId = productId;
        this.cost = cost;
        this.buttonLabel.text = $"Purchase for {resourceProductionData.GetActualCosts(this.Amount,this.cost)}{_resourceProductionData.costResource.name}";
    }

    void UpdateTextColor() => this.buttonLabel.color = this.IsAffordable ? Color.black : Color.red;

    public void Purchase() {
        if (this.IsAffordable) {
            _resourceProductionData.costResource.ReduceResource(this._resourceProductionData.GetActualCosts(this.Amount, this.cost));
            this.Amount++;
            this.buttonLabel.text = $"Purchase for {this._resourceProductionData.GetActualCosts(this.Amount, this.cost)} {_resourceProductionData.costResource.name}";
            
        }
    }
}


