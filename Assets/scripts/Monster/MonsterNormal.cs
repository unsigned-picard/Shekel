using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterNormal : Monster {

    public MonsterNormal(): base() {
        this.name = "MonsterNormal";
        this.life = 30f;
        this.speed = 15f;
        this.moneyEquivalent = 20;
    }
    // Start is called before the first frame update
    void Start() {
        this.oldColor = this.gameObject.GetComponent<Renderer>().material.color;
        agent.SetDestination(EndPoint.transform.position);
        agent.speed = this.speed;
        this.maxLife = this.life;
    }

    // Update is called once per frame
    void Update() {
        
    }

    public new String ToString() {
        return base.ToString();
    }
}
