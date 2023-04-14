using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LifeUI : MonoBehaviour
{
    public TextMeshProUGUI LifeCounterText;

    // Update is called once per frame
    void Update()
    {
        if(PlayerStats.playerLife > 1)
            LifeCounterText.text = "Vies : " + PlayerStats.playerLife.ToString();
        else
            LifeCounterText.text = "Vie : " + PlayerStats.playerLife.ToString();
    }
}
