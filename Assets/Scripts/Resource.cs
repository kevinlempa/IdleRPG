using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu]
public class Resource : ScriptableObject {

   public event System.Action ResourceChanged;
    [SerializeField] private int goldAmountPerClick = 5;
    private int _resourceAmount;

    public int ResourceAmount {
        get => _resourceAmount;
        set {
            _resourceAmount = value;
            ResourceChanged?.Invoke();
        }
    }

    public void AddResource() {
        ResourceAmount += goldAmountPerClick;
    }

    public void AddResource(int goldToAdd) {
        if (goldToAdd > 0)
            ResourceAmount += goldToAdd;
    }

    public void ReduceResource(int reduceBy) {
        if (ResourceAmount < reduceBy) {
            return;
        } else ResourceAmount -= reduceBy;
    }
}