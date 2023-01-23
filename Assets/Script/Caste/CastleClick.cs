using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleClick : MonoBehaviour
{
    private Animator _castleAnimation;
    public int MoneyCount;
    [SerializeField]
    private AudioSource audio;
  
    private void Start()
    {
        _castleAnimation = GetComponent<Animator>();
        audio.GetComponent<AudioSource>();
    }
    private void OnMouseDown()
    {
        if (DataHolder.StartGame = true)
        {
            PlusMoney();
        }
        
    }
    private void PlusMoney()
    {
        DataHolder.Money += MoneyCount;
        audio.Play();
    }
}
