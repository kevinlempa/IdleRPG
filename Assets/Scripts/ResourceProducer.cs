using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public partial class ResourceProducer : MonoBehaviour {
    public ResourceProductionData resourceProductionData;
    public Text upgradeAmountText;
    public Text AmountText;
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
        this.AmountText.text = this.amount.Amount.ToString($"0 {this.resourceProductionData.name}");
    }


    public void SetUp(ResourceProductionData resourceProductionData) {
        this.resourceProductionData = resourceProductionData;
        this.gameObject.name = resourceProductionData.name;
        this.amount.SetUp(resourceProductionData, this.resourceProductionData.costResource, "Count", this.resourceProductionData.cost);
        this.upgrade.SetUp(resourceProductionData, this.resourceProductionData.costResource, "Level", this.resourceProductionData.upgradeCost);
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
            yield return new WaitForSeconds(resourceProductionData.productionTime);
            ProduceGold();
        }
    }

    void ProduceGold() {
        
        if (this.amount.Amount == 0)
            return;
        var resourcePerSecond = Mathf.RoundToInt(this.resourceProductionData.productionAmount * this.amount.Amount *
                                             Mathf.Pow(resourceProductionData.upgradePercantage, this.upgrade.Amount));
        resourceProductionData.produceResource.AddResource(resourcePerSecond);
        var instance = Instantiate(floatingText, transform);
        instance.text = $"+{resourcePerSecond} {resourceProductionData.produceResource.name}";
    }
}