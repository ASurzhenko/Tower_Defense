using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Wave")]
public class Wave_SO : ScriptableObject
{
    public float Duration;
    public List<Enemy_SO> Enemies;
}
