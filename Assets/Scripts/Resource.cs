using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu]
public class Resource : ScriptableObject {

   public event System.Action ResourceChanged;
    [SerializeField] private int resourcePerClick = 5;
    private int _resourceAmount;

    public int ResourceAmount {
        get => PlayerPrefs.GetInt(name, 0);
        set {
            PlayerPrefs.SetInt(name, value);
            ResourceChanged?.Invoke();
        }
    }

    public void AddResource() {
        ResourceAmount += resourcePerClick;
    }

    public void AddResource(int addAmount) {
        if (addAmount > 0)
            ResourceAmount += addAmount;
    }

    public void ReduceResource(int reduceBy) {
        if (ResourceAmount < reduceBy) {
            return;
        } else ResourceAmount -= reduceBy;
    }
}