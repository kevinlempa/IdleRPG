using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gold : MonoBehaviour {
    [SerializeField] private UnityEvent goldChange;
    private int _goldAmount;
    public int GoldAmount {
        get => _goldAmount;
        private set {
            goldChange?.Invoke();
            _goldAmount = value;
        }
    }

    [SerializeField] private int goldAmountPerClick;


    public void AddGold() {
        GoldAmount += goldAmountPerClick;
        
    }

    public void AddGold(int goldToAdd) {
        if (goldToAdd > 0)
            GoldAmount += goldToAdd;
        
    }

    public void ReduceGold(int reduceGoldBy) {
        if (GoldAmount < reduceGoldBy) {
            return;
        } else GoldAmount -= reduceGoldBy;
        
    }

    private void Start() {
        this.GoldAmount = PlayerPrefs.GetInt("Gold", 1);
    }

    private void OnDestroy() {
        PlayerPrefs.SetInt("Gold", this.GoldAmount);
    }
}