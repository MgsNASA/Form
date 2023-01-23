using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlizScript : MonoBehaviour
{
    [SerializeField]
    private GameObject minion;
    private void Hit()
    {
        
        Instantiate(minion,null);
       
    }
}
