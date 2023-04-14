using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

internal class Slowed : MonoBehaviour, State
{
    public Slowed(Monster m) {
        m.agent.speed = 1;
        m.gameObject.GetComponent<Renderer>().material.color = new Color(233, 79, 55);
        GameObject tmpEffect = (GameObject)Instantiate(m.slowEffect, m.transform.position, m.transform.rotation);
        Destroy(tmpEffect, .5f);
    }
}