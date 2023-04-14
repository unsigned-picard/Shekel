using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTurret : Turret {
    public FireTurret() : base() {
        this.damage = 30;
        this.range = 30;
        this.level = 1;
        this.sellPrice = 1500;
        this.upgradePrice = 4500;
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
