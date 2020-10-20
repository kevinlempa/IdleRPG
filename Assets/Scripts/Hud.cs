using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour {
    public Text goldText;
    private Gold gold;
    void Start() {
        gold = FindObjectOfType<Gold>();
    }

    void Update() {
        goldText.text = $"Gold : {gold.GoldAmount}";
    }
}