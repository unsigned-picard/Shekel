using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour {
    public GameObject UI;
    public Text upgradeText;
    public Text sellText;
    private Node target;
    private Turret turret;

    public void SetTarget(Node target) {
        if (target == this.target && UI.activeSelf) {
            Hide();
            return;
        }
        this.turret = target.currentTurret.GetComponent<Turret>();
        upgradeText.text = " AMÉLIORER\r\n$" + this.turret.getUpgradePrice();
        sellText.text = " VENDRE\r\n$" + this.turret.getSellPrice();
        this.UI.SetActive(true);
        this.target = target;
        transform.position = target.transform.position;
    }

    public void Upgrade() {
        if(turret.CanUpgrade()) {
            turret.Upgrade();
        }
    }

    public void Sell() {
        turret.Sell();
        Hide();
    }

    void Start() {
        Hide();
    }

    public void Hide(){
        this.UI.SetActive(false);
    }
}
