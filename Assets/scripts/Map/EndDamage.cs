using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndDamage : MonoBehaviour
{
    public float range;
    public float damaga;
    public EndDamage()
    {
        this.range = 15f;
        this.damaga = 1f;
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] monsters = GameObject.FindGameObjectsWithTag("monster");
        foreach (GameObject monster in monsters)
        {
            float distance = Vector3.Distance(transform.position, monster.transform.position);
            if (distance <= range)
            {
                if(PlayerStats.playerLife > 0)
                    PlayerStats.playerLife -= 1;
                Destroy(monster);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;  
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
