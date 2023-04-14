using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaterTurret : Turret {
    public WaterTurret() : base() {
        this.damage = 10;
        this.range = 15;
        this.level = 1;
        this.sellPrice = 500;
        this.upgradePrice = 1500;
    }

    void Start() {
        InvokeRepeating("UpdateTarget", 0f, .5f);
    }
    void Update() {
        base.Update();
        
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, this.range);
    }
}
