using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BestWave : MonoBehaviour
{

    [SerializeField]
    public Text waveScore;
    void Awake()
    {
        waveScore.text =Progress.Instance.PlayerInfo.Wave.ToString();
    }

   
    void Update()
    {
        
    }
}
