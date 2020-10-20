using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoad : MonoBehaviour {
    private Gold gold;
    private GoldPress goldPress;
    void Start() {
        gold = FindObjectOfType<Gold>();
        goldPress = FindObjectOfType<GoldPress>();
        gold.GoldAmount = PlayerPrefs.GetInt("Gold", 0);
        goldPress.productionCost = PlayerPrefs.GetInt("Production Cost", 100);
        goldPress.goldPressOwned = PlayerPrefs.GetInt("Gold presses owned", 0);
        goldPress.goldPerSecondPerPress = PlayerPrefs.GetInt("Gold per second per press", 1);

    }

    private void OnDestroy() {
        PlayerPrefs.SetInt("Gold", gold.GoldAmount);
        PlayerPrefs.SetInt("Production Cost", goldPress.productionCost);
        PlayerPrefs.SetInt("Gold presses owned", goldPress.goldPressOwned);
        PlayerPrefs.SetInt("Gold per second per press", goldPress.goldPerSecondPerPress);
    }
    
}
