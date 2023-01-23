using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CreateNpc : MonoBehaviour
{
    [SerializeField]
    private Text TimerText;
    [SerializeField]
    private  GameObject gameObject;
    public Transform[] spawnLocation;
    [SerializeField]
    private int cost;
    [SerializeField]
    private int MaxCount;
    [SerializeField]
    private AudioSource audioSource;
    void Start()
    {
        TimerText.text = cost.ToString();
    }
    public void CreateWarior()
    {
        if (DataHolder.Money>= cost && DataHolder.CountNpc<=15 )
        {
            Instantiate(gameObject, spawnLocation[Random.Range(0, spawnLocation.Length)]);
            DataHolder.Money -= cost;
            DataHolder.CountNpc += 1;
            audioSource.Play();
            cost += 20;
            TimerText.text = Mathf.Round(cost).ToString();
        }
    }
    
}
