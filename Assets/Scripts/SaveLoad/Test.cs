using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(3);
        //PlayerData.SetInt("Cash", 100);
        //PlayerData.Save();
        print(PlayerData.GetInt("Cash"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
