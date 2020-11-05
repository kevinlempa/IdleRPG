using System;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour {
    public Text goldText;
    public Resource gold;

    private void Update() {
        UpdateGold();
    }

    public void UpdateGold() {
        goldText.text = $"Gold : {gold.ResourceAmount}";
    }
}