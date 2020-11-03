using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class ProductionPopup : MonoBehaviour {
    public float movementSpeed = 5f;
    public float alphaFadeSpeed;

    void Update() {
        this.transform.position += Vector3.up * this.movementSpeed * Time.deltaTime;
        var text = GetComponent<Text>();
        var color = text.color;
        color.a -= this.alphaFadeSpeed * Time.deltaTime;
        text.color = color;
        if (color.a < 0) {
            Destroy(this.gameObject);
        }
    }
}