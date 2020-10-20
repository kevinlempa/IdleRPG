using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour {
    public int GoldAmount { get; private set; }
    [SerializeField]private int addGold;


   public void AddGold() {
        GoldAmount += addGold;
    }
}