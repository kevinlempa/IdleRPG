using System;
using UnityEngine;


public class GoldProductionSetup : MonoBehaviour {
    public ResourceProductionData[] goldProductionUnits;
    public Transform goldProductionUnitParent;
    public GameObject goldProductionUnitPrefab;

    private void Start() {
        foreach (var productionUnit in this.goldProductionUnits) {
            var instance = Instantiate(this.goldProductionUnitPrefab, this.goldProductionUnitParent);
            instance.GetComponent<ResourceProducer>().SetUp(productionUnit);
        }
    }
}