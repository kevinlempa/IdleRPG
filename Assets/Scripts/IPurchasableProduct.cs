using UnityEngine;
public interface IPurchasableProduct {
        string Name { get; set; }
        int Cost { get; set; }
        int ProductionTime { get; set; }
        int ProductionAmount { get; set; }
    }
