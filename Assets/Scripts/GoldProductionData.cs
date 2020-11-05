using UnityEngine;

[CreateAssetMenu]
public class GoldProductionData : ScriptableObject {
    public int cost = 100;
    public int upgradeCost = 200;
    public int productionAmount = 1;
    public float productionTime = 1f;
    [SerializeField] float costMultiplier = 1.1f;
    public float upgradePercantage = 1.05f;

    public int GetActualCosts(int amount, int cost) {
        var result = cost * Mathf.Pow(this.costMultiplier, amount);
        return Mathf.RoundToInt(result);
    }
}