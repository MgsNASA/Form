using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour
{
    private GameObject boss;

    private void Start()
    {
        boss = GameObject.Find("Pop");
        transform.position = boss.transform.position;
    }
   
}
