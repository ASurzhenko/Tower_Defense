using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed;
    public int Id;
    float Damage;
    public float Health{get; private set;}
    public float Reward{get; private set;}
    Transform targetTransform;
    int waypoinIndex;
    Animator myAnimator;
    public bool isDead;
    private void Awake() {
        myAnimator = GetComponent<Animator>();
    }
    private void OnEnable() {
        UIManager.OnGameOver += () => Destroy(gameObject);
        targetTransform = WayPoints.Instance.Way_Points[0];
        waypoinIndex = 0;
        isDead = false;
    }
    private void OnDisable() {
        UIManager.OnGameOver -= () => Destroy(gameObject);
    }
    public void SetUp(IEnemy enemyData)
    {
        Speed = enemyData.GetEnemySpeed();
        Damage = enemyData.GetDamage();
        Health = enemyData.GetHealth();
        Reward = enemyData.GetReward();
    }
    private void Update()
    {
        if(isDead) return;
        if(Health <= 0 && !isDead)
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
            MakeDamage();
            gameObject.SetActive(false);
            return;
        }

        waypoinIndex++;
        targetTransform = GetNextWayPoint();
    }
    Transform GetNextWayPoint()
    {
        return WayPoints.Instance.Way_Points[waypoinIndex];
    }
    public Transform GetLastWayPoint()
    {
        return WayPoints.Instance.Way_Points[waypoinIndex];
    }

    void MakeDamage()
    {
        PData.PlayerHealth -= Damage;
        if(PData.PlayerHealth <= 0)
        {
            UIManager.Instance.ShowGameOverPanel();
        }
    }
    public void TakeDamage(float damage)
    {
        Health -= damage;
    }
    void Die()
    {
        if(AudioManager.Instance.isSfxOn())
            AudioManager.Instance.PlaySound(SoundEnum.EnemyDeath);

        isDead = true;
        myAnimator.SetTrigger("death");

        PData.SoftCash += Reward;

        VFXEffector.Instance.CoinEffect(transform.position);
    }
}
