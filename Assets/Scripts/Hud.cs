using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour {
    public Text goldText;
    private Gold gold;

    void Awake() {
        gold = FindObjectOfType<Gold>();
    }

    public void UpdateGold() {
        goldText.text = $"Gold : {gold.GoldAmount}";
    }
    
}