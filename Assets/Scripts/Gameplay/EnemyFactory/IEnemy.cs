using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    float GetDamage();
    GameObject GetEnemyPrefab();
    float GetEnemySpeed();
}
