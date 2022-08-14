using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class CurrentEnemyFactory : EnemyFactory
{
    private readonly Wave_SO wave;
    public CurrentEnemyFactory(Wave_SO wave)
    {
        this.wave = wave;
    }
    public override IEnemy GetEnemy()
    {
        CurrentEnemy enemy = new CurrentEnemy(wave);
        return enemy;
    }
}
