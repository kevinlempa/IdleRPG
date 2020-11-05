using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoad : MonoBehaviour {
    public Resource gold;

    void Start() {
        gold.ResourceAmount = PlayerPrefs.GetInt("Gold", 0);
    }

    private void OnDestroy() {
        PlayerPrefs.SetInt("Gold", gold.ResourceAmount);
    }
}