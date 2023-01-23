using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public float timeStart = 0;
    public Text TimerText;
    void Start()
    {
        TimerText.text = timeStart.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (DataHolder.StartGame == true) 
        {
            timeStart += Time.deltaTime;
            TimerText.text = Mathf.Round(timeStart).ToString();
        }
          
    }
}
