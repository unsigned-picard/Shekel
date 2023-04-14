using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public abstract class Monster: MonoBehaviour
{
    public GameObject slowEffect;
    public GameObject aliveEffect;
    public GameObject deathEffect;
    public float maxLife;
    public float life;
    public float speed;
    public String name;
    public State state;
    public NavMeshAgent agent;
    public GameObject EndPoint;
    public int moneyEquivalent;
    protected Color oldColor;

    public Image healthBar;

    public void Awake()
    {
        this.state = new Alive(this);
    }
    public void Die()
    {
        this.state = new Dead(this);
        Destroy(this.gameObject);
    }
    public void TakeDamage(float damage)
    {
        this.life -= damage;
        healthBar.fillAmount = life/maxLife;
        if (this.life <= 0 )
        {
            Die();
        }
    }
    public void SetEffect(int effect)
    {
        switch(effect)
        {
            case 1:
                this.state = new Slowed(this);
                break;
            default:
                break;
        }
        StartCoroutine(WaitRemoveEffect());
    }

    IEnumerator WaitRemoveEffect()
    {
        yield return new WaitForSeconds(1);
        agent.speed = this.speed;
        gameObject.GetComponent<Renderer>().material.color = oldColor;

    }

    public new string ToString()
    {
        return "Je suis un monstre avec " + this.life + " points de vie et je cours � une vitesse de " + this.speed + " mon statut actuel est " + this.state; 
    }
}
