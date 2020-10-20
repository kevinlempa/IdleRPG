using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour {
    public Text goldText;
    private int goldAmount;

    void Start() {
        goldAmount = FindObjectOfType<Gold>().GoldAmount;
    }

    public void UpdateGold() {
        goldAmount = FindObjectOfType<Gold>().GoldAmount;
    }

    void Update() {
        goldText.text = $"Gold : {goldAmount}";
    }
}