using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atack : MonoBehaviour
{
    [SerializeField]
    private int colisionAtack;
    [SerializeField]
    private float recharge;
    [SerializeField]
    private float startRecharge;
    private Rigidbody2D rb;
    private Animator _animator;
    [SerializeField]
    private string stringPlayer;
  
    private Transform transform;
    private Health health;
    [SerializeField]
    private int countToAtack;

    private void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    void Update() 
    {
        recharge += Time.deltaTime;
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
       
        if (recharge >= startRecharge)
        {
            if (collision.CompareTag(stringPlayer) )
            {
                
                _animator.SetTrigger("Attack");
                recharge = 0;
                health = collision.GetComponent<Health>();

            }
            else
            { 
            
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (colisionAtack > 0)
        {
            _animator.SetTrigger("Death");
        }
        
    }
    public void TakeDamage()
    {
        health.TakeDamage(countToAtack);
    }
   
   
}
