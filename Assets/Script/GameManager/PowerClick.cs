using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerClick : MonoBehaviour
{
   
    private int costimproveclick;
    public void Plus()
    {
        if (DataHolder.Money >= costimproveclick)
        {
            DataHolder.PowerClick += 1;
            costimproveclick += 30;
        }
    
    }
}
