using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    GameObject GetEnemyPrefab();
    float GetDamage();
    float GetEnemySpeed();
    float GetHealth();
    float GetReward();
}
