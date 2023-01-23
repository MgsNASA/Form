using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionAtack : MonoBehaviour
{
    [SerializeField]
    private Health health;
    [SerializeField]
    private Animator _animator;
    private void Awake()
    {
        _animator=GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Npc"))
        {
            _animator.SetTrigger("Death");
            health = collision.gameObject.GetComponent<Health>();
            health.TakeDamage(20);
            Debug.Log("20");
        }

    }
}
