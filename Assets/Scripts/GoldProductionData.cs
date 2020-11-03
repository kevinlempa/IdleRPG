using UnityEngine;

[CreateAssetMenu]
public class GoldProductionData : ScriptableObject {
    [SerializeField] int cost = 100;
    [SerializeField] private int upgradeCost = 200;
    public int productionAmount = 1;
    public float productionTime = 1f;
    [SerializeField] float costMultiplier = 1.1f;
    public float upgradePercantage = 1.05f;
    public int GetActualCosts(int amount) {
        var result = this.cost * Mathf.Pow(this.costMultiplier, amount);
        return Mathf.RoundToInt(result);
    }

    public int GetUpgradeCost(int amount) {
        var result = this.upgradeCost * Mathf.Pow(this.costMultiplier, amount);
        return Mathf.RoundToInt(result);
    }
    
}