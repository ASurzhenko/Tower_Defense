using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform target;
    float damage;
    float speed = 30f;
    public void SetUp(Transform target, float damage)
    {
        this.target = target;
        this.damage = damage;
    }
    private void Update() {
        if(target == null)
        {
            gameObject.SetActive(false);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float dist = Vector3.Distance(target.position, transform.position);
        if(dist <= 0.3f)
        {
            Hit();
            return;
        }

        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
    }

    void Hit()
    {
        target.GetComponent<Enemy>().TakeDamage(damage);
        gameObject.SetActive(false);
    } 
}
