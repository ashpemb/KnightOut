using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EnergySystem : MonoSingleton<EnergySystem> {

    public int maxEnergy = 20;
    public int currentEnergy;
    float checkTimer = 0.0f;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("Cooldown"))
        {
            SetTime();
        }
        if (PlayerPrefs.HasKey("Energy"))
        {
            currentEnergy = PlayerPrefs.GetInt("Energy");
        }
        else
        {
            currentEnergy = maxEnergy;
        }
        ReadTime();
    }

    private void FixedUpdate()
    {
        checkTimer += Time.fixedDeltaTime;
        if (checkTimer >= 1.0f)
        {
            ReadTime();
            checkTimer = 0f;
        }
    }

    void SetTime ()
    {
        var timeWhenCooldownFinishes = DateTime.Now.AddMinutes(1);
        string dataString = timeWhenCooldownFinishes.ToBinary().ToString();
        PlayerPrefs.SetString("Cooldown", dataString);
        PlayerPrefs.Save();
    }

    void ReadTime()
    {
        if (PlayerPrefs.HasKey("Cooldown"))
        {
            var cooldown = Convert.ToInt64(PlayerPrefs.GetString("Cooldown"));
            TimeSpan timeLeft = DateTime.FromBinary(cooldown).Subtract(DateTime.Now);
            Debug.Log("TIME LEFT:" + timeLeft.Seconds.ToString("D2") + " seconds");
            Debug.Log("CURRENT ENERGY:" + currentEnergy);
            if (timeLeft.TotalSeconds < 0)
            {
                int energy = 1 + (timeLeft.Minutes * -1);
                Debug.Log("Energy Added = " + energy);
                currentEnergy += energy;
                if(currentEnergy > maxEnergy)
                {
                    currentEnergy = maxEnergy;
                }
                PlayerPrefs.SetInt("Energy", currentEnergy);
                SetTime();
            }
        }
    }

}
