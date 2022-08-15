using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform target;
    float speed = 30f;
    public void SetUp(Transform target)
    {
        this.target = target;
    }
    private void Update() {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float dist = Vector3.Distance(target.position, transform.position);
        if(dist <= 0.3f)
        {
            //Hit
            gameObject.SetActive(false);
            return;
        }

        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
    }

    void Hit()
    {
        
    } 
}
