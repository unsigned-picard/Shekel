using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

internal class Dead : MonoBehaviour, State
{
    public Dead(Monster m) {
        PlayerStats.playerMoney += m.moneyEquivalent;
        GameObject tmpEffect = (GameObject)Instantiate(m.deathEffect, m.transform.position, m.transform.rotation);
        Destroy(tmpEffect, .5f);
    }
}