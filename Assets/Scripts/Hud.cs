using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour {
    public Text goldText;
    public Text coalText;
    public Text woodText;
    public Resource gold;
    public Resource coal;
    public Resource wood;
    

    private void Update() {
        UpdateResources();
    }

    public void UpdateResources() {
        goldText.text = $"{gold.name}: {gold.ResourceAmount}";
        coalText.text = $"{coal.name}: {coal.ResourceAmount}";
        woodText.text = $"{wood.name}: {wood.ResourceAmount}";
    }
}