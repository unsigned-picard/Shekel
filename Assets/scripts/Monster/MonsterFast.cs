using System;
using UnityEngine;

public class MonsterFast : Monster
{
    public MonsterFast() : base()
    {
        this.name = "MonsterFast";
        this.life = 15f;
        this.speed = 30f;
        this.moneyEquivalent = 100;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.oldColor = this.gameObject.GetComponent<Renderer>().material.color;
        this.maxLife = this.life;
        agent.SetDestination(EndPoint.transform.position);
        agent.speed = this.speed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public new String ToString()
    {
        return base.ToString();
    }
}