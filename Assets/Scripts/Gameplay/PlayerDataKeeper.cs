using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataKeeper : MonoBehaviour
{
    public static PlayerDataKeeper Instance;
    public PlayerData_SO playerData_SO;
    private void Awake() {
        Instance = this;
    }
}
