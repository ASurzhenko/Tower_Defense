using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentEnemy : IEnemy
{
    private readonly Wave_SO wave;
    public float Damage{get; set;}
    public float Health{get; set;}
    public CurrentEnemy(Wave_SO wave)
    {
        this.wave = wave;
        Damage = wave.Enemies[0].Damage;
        Health = wave.Enemies[0].HealthAmount;
    }

    public float GetDamage()
    {
        return Damage;
    }

    public Wave_SO GetWave() => wave;

    public GameObject GetEnemyPrefab()
    {
        return wave.Enemies[0].EnemyPrefab;
    }

    public float GetEnemySpeed()
    {
        return wave.Enemies[0].MovingSpeed;
    }
}
