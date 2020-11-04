using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoad : MonoBehaviour {
    private Gold gold;
    private GoldProducer goldProducer;

    void Start() {
        gold = FindObjectOfType<Gold>();
        gold.GoldAmount = PlayerPrefs.GetInt("Gold", 0);
    }

    private void OnDestroy() {
        PlayerPrefs.SetInt("Gold", gold.GoldAmount);
    }
}