using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyUI : MonoBehaviour {
    public TextMeshProUGUI moneyCounterText;
    // Update is called once per frame
    void Update() {
        moneyCounterText.text = PlayerStats.playerMoney.ToString() + "₪";
    }
}
