using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusMoney : MonoBehaviour
{
    
    [SerializeField]
    private int _countToDie;
    [SerializeField]
    private int _countClick=0;
    [SerializeField] private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void OnMouseDown()
    {
        Plus();
    }
    public void Plus()
    {

        if (_countClick <= _countToDie)
        {
            _animator.SetTrigger("Hit");
            _countClick++;
            _countClick += DataHolder.PowerClick;
        }
        else
        {
            _animator.SetTrigger("Death");
            gameObject.GetComponent<EnemyMoveMent>().enabled = false;
        }
        
    }
}
