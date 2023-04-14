using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;


// Interface de gestion des tours
public abstract class Turret: MonoBehaviour {

    public int damage;
    public float range;
    public float cadence;
    public int level;
    public int MAX_LEVEL = 10;
    public int price;
    public int sellPrice; 
    public int upgradePrice;
    public int effect;
    public Monster monsterTarget;
    public Transform targetPos;
    public GameObject partToRotate;
    public float turnSpeed = 20f;
    public GameObject firePos;
    public GameObject bullet;
    public GameObject startPos;
    public bool firstBulletSend = false;
    public bool wait = false;
    public bool inUpgrade = false;

    //Getter
    public int getSellPrice() { return sellPrice; }
    public int getUpgradePrice() { return upgradePrice; }

    public void Update() {
        if (targetPos == null) {
            LockOnStart();
            return;
        }
        LockOnTarget();
    }

    //Gestion du statut des tours
    public void Upgrade() {
        if (this.level < MAX_LEVEL && upgradePrice <= PlayerStats.playerMoney) {
            this.level += 1;
            this.cadence /= this.level;
            this.damage += (this.level*2);
            this.range += (this.level * 2);
            PlayerStats.playerMoney -= upgradePrice;
        }
    }

    public bool CanUpgrade() {
        return this.level < MAX_LEVEL && upgradePrice <= PlayerStats.playerMoney;
    }

    public void Sell() {
        PlayerStats.playerMoney += sellPrice;
        Destroy(gameObject);
    }

    //Gestion de la cible de la tour
    void LockOnStart() {
        Vector3 dir = startPos.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void LockOnTarget() {
        Vector3 dir = targetPos.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void UpdateTarget() {
        float shortestDistance = Mathf.Infinity;
        GameObject[] monsters = GameObject.FindGameObjectsWithTag("monster");
        GameObject nearestMonster = null;
        foreach (GameObject monster in monsters) {
            float distance = Vector3.Distance(transform.position, monster.transform.position);
            if (distance < range) {
                shortestDistance = distance;
                nearestMonster = monster;
            }
        }

        if (nearestMonster != null && shortestDistance <= range) {
            targetPos = nearestMonster.transform;
            monsterTarget = nearestMonster.GetComponent<Monster>();
            StartCoroutine(Shoot());
        } else {
            targetPos = null;
        }

    }

    public virtual IEnumerator Shoot() {
        if(!wait) {
            wait = true;
            if (firstBulletSend) {
                yield return new WaitForSecondsRealtime(this.cadence);
            }
            else {
                firstBulletSend = true;
            }
            GameObject bulletGO = (GameObject)Instantiate(bullet, firePos.transform.position, firePos.transform.rotation);
            Bullet spawnedBullet = bulletGO.GetComponent<Bullet>();

            if (spawnedBullet != null)
                spawnedBullet.Seek(monsterTarget, this.damage);
            wait = false;
        }
    }
}
