using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal abstract class EnemyFactory
{
    public abstract IEnemy GetEnemy();
}
