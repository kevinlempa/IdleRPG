using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour {

    public int GoldAmount { get; private set; }
    [SerializeField]private int addGold;


   public void AddGold() {
        GoldAmount += addGold;
    }
   private void Start() {
       this.GoldAmount = PlayerPrefs.GetInt("Gold", 1);
   }
     
         private void OnDestroy() {
             PlayerPrefs.SetInt("Gold", this.GoldAmount);
         }

}