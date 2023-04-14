using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform targetTransform;
    private Monster target;
    private int damage;
    private int effect;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Seek(Monster _target, int damage, int effect = 0)
    {
        targetTransform = _target.transform;
        target = _target;
        this.damage = damage;
        this.effect = effect;

    }

    // Update is called once per frame
    void Update()
    {
        if (targetTransform == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = targetTransform.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(targetTransform);
    }

    void HitTarget()
    {
        Destroy(gameObject);
        target.TakeDamage(this.damage);
        target.SetEffect(this.effect);
    }
}
