using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed;
    public int Id;
    float Damage;
    float Health;
    Transform targetTransform;
    int waypoinIndex;
    private void OnEnable() {
        targetTransform = WayPoints.Instance.Way_Points[0];
        waypoinIndex = 0;
    }
    public void SetUp(IEnemy enemyData)
    {
        this.Speed = enemyData.GetEnemySpeed();
        this.Damage = enemyData.GetDamage();
        this.Health = enemyData.GetHealth();
    }
    private void Update()
    {
        if(Health <= 0)
        {
            Die();
            return;
        }

        Vector2 direction = targetTransform.position - transform.position;
        transform.Translate(direction.normalized * Speed * Time.deltaTime, Space.World);

        if(Vector2.Distance(transform.position, targetTransform.position) <= 0.1f)
        {
            MoveNext();
        }
    }
    void MoveNext()
    {
        if(waypoinIndex >= WayPoints.Instance.Way_Points.Length - 1)
        {
            gameObject.SetActive(false);
            return;
        }

        waypoinIndex++;
        targetTransform = WayPoints.Instance.Way_Points[waypoinIndex];
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
    }
    void Die()
    {

    }
}
