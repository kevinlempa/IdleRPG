using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gold : MonoBehaviour {
    [SerializeField] private UnityEvent goldChange;
    [SerializeField] private int goldAmountPerClick = 5;
    private int _goldAmount;

    public int GoldAmount {
        get => _goldAmount;
        set {
            _goldAmount = value;
            goldChange?.Invoke();
        }
    }

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
        goldChange?.Invoke();
    }
}