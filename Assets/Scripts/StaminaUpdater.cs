using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaUpdater : MonoBehaviour {

    public Text text;

    private void Start()
    {
        text = this.GetComponent<Text>();
    }

    private void LateUpdate()
    {
        text.text = "STAMINA: " + EnergySystem.instance.currentEnergy + "/" + EnergySystem.instance.maxEnergy;
    }
}
