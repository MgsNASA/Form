using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoneyText : MonoBehaviour
{
    
    public Text moneyText;
    void Start()
    {
        moneyText.text = DataHolder.Money.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = Mathf.Round(DataHolder.Money).ToString();
    }
}
