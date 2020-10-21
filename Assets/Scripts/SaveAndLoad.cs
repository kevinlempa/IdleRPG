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
        goldPress.cost = PlayerPrefs.GetInt("Production Cost", 100);
        goldPress.goldPressAmount = PlayerPrefs.GetInt("Gold presses owned", 0);
        goldPress.productionAmount = PlayerPrefs.GetInt("Gold per second per press", 1);

    }

    private void OnDestroy() {
        
        PlayerPrefs.SetInt("Gold", gold.GoldAmount);
        PlayerPrefs.SetInt("Production Cost", goldPress.cost);
        PlayerPrefs.SetInt("Gold presses owned", goldPress.goldPressAmount);
        PlayerPrefs.SetInt("Gold per second per press", goldPress.productionAmount);
    }
    
}
