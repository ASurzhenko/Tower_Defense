using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDataKeeper : MonoBehaviour
{
    public static TowerDataKeeper Instance;
    [SerializeField] Tower_SO[] Towers_SO;
    [SerializeField] GameObject Bullet;
    private void Awake() {
        Instance = this;
    }
    public Tower_SO GetTower(int towerIndex)
    {
        return Towers_SO[towerIndex];
    }
    public GameObject GetBullet() => Bullet;
}
