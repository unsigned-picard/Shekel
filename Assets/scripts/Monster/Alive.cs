using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;
public class Alive : MonoBehaviour, State
{
    public Alive(Monster m)
    {
        //GameObject tmpEffect = (GameObject)Instantiate(m.aliveEffect, m.transform.position, m.transform.rotation);
        //Destroy(tmpEffect, .5f);
    }
}