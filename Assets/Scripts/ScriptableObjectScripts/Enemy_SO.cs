using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Enemy")]
public class Enemy_SO : ScriptableObject
{
    public float HealthAmount;
    public float MovingSpeed;
    public float Damage;
}
