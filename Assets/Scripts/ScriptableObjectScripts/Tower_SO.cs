using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Tower")]
public class Tower_SO : ScriptableObject
{
    public GameObject TowerPrefab;
    public Sprite TowerSprite;
    public int BuildPrice;
    public float Range;
    public float ShootInterval;
    public float Damage;
}