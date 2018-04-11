using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CostUpdater : MonoBehaviour {

    Text text;
    int cost;

	// Use this for initialization
	void Start () {
        cost = this.GetComponentInParent<LevelContainer>().enemy.StaminaCost;
        text = this.GetComponent<Text>();
        text.text = cost.ToString();
	}
	
}
