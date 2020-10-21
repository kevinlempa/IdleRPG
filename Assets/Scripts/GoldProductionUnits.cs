using System;
using UnityEngine;


public class GoldProductionUnits : MonoBehaviour {
    public GoldProductionUnit[] goldProductionUnits;
    public Transform goldProductionUnitParent;
    public GameObject goldProductionUnitPrefab;

    private void Start() {
        foreach (var productionUnit in this.goldProductionUnits) {
            var instance = Instantiate(this.goldProductionUnitPrefab, this.goldProductionUnitParent);
            instance.GetComponent<GoldProductionUnitScript>().SetUp(productionUnit);
        }
    }
}