using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlace : MonoBehaviour
{
    public enum TowerState
    {
        Empty,
        Tower
    }

    Tower_SO tower_SO;
    private void OnMouseUpAsButton() {
        tower_SO = TowerDataKeeper.Instance.GetTower(Random.Range(0, 4));
        GameObject tower = Instantiate(tower_SO.TowerPrefab, transform.position, Quaternion.identity, transform);
        tower.GetComponentInChildren<Tower>().SetUp(tower_SO);
    }
}
