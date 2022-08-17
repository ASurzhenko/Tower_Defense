using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentEnemy : IEnemy
{
    private readonly Wave_SO wave;
    public CurrentEnemy(Wave_SO wave)
    {
        this.wave = wave;
    }
    public float GetDamage()
    {
        return wave.Enemies[0].Damage;
    }
    public GameObject GetEnemyPrefab()
    {
        return wave.Enemies[0].EnemyPrefab;
    }
    public float GetEnemySpeed()
    {
        return wave.Enemies[0].MovingSpeed;
    }
    public float GetHealth()
    {
        return wave.Enemies[0].HealthAmount;
    }

    public float GetReward()
    {
        return wave.Enemies[0].KillingReward;
    }
}
