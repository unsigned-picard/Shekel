using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTurret : Turret {
    public IceTurret() : base() {
        this.damage = 10;
        this.range = 15;
        this.level = 1;
        this.sellPrice = 500;
        this.upgradePrice = 1500;
        this.effect = 1;
    }

    void Start() {
        InvokeRepeating("UpdateTarget", 0f, .5f);
    }

    void Update(){
        base.Update();
    }

    public override IEnumerator Shoot() {
        if (!wait){
            wait = true;
            if (firstBulletSend){
                yield return new WaitForSecondsRealtime(this.cadence);
            }
            else{
                firstBulletSend = true;
            }
            GameObject bulletGO = (GameObject)Instantiate(bullet, firePos.transform.position, firePos.transform.rotation);
            Bullet spawnedBullet = bulletGO.GetComponent<Bullet>();

            if (spawnedBullet != null)
                spawnedBullet.Seek(monsterTarget, this.damage, this.effect);
            wait = false;
        }
    }

    private void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, this.range);
    }
}
