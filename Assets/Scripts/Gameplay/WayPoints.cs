using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    public static WayPoints Instance;
    [SerializeField] Transform[] wayPoints;
    public Transform[] Way_Points
    {
        get
        {
            return wayPoints;
        }
        private set
        {
            wayPoints = value;
        }
    }
    private void Awake() {
        Instance = this;
    }
    
}
