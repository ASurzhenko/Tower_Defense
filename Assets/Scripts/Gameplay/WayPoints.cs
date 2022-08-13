using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    public static WayPoints Instance;
    [SerializeField] Transform[] wayPoints;
    private void Awake() {
        Instance = this;
    }
    
}
