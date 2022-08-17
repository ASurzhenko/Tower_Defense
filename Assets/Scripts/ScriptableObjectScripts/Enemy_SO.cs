using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Enemy")]
public class Enemy_SO : ScriptableObject
{
    public GameObject EnemyPrefab;
    public float HealthAmount;
    public float MovingSpeed;
    public float Damage;
    public float KillingReward;
}
