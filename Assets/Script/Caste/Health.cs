using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameRegim gameRegim;
    [SerializeField]
    private int maxHealth = 100;
    [SerializeField]
    public int currentHealth;
    [SerializeField]
    private HeartBar healthBar;
    private Animator anim;
    private PlusMoney plusMoney;
    [SerializeField]
    private int _plusMoneyCount;
    [SerializeField]
    private AudioSource death;
    [SerializeField]
    private AudioSource hurt;
    private void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        plusMoney = GetComponent<PlusMoney>();
    
    }
    private void Update()
    {

        if (currentHealth<=0)
        {
           
            anim.SetTrigger("Death");
            anim.SetBool("GameOver",true);

        }
       
    }
    public void TakeDamage( int damage)
    {
       
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    private void Death()
    {

        gameObject.SetActive(false);
        DataHolder.Money += _plusMoneyCount;
        DataHolder.CountNpc -= 1;
    }
    private void DeathSound()
    {
        death.Play();
    }
    private void HurtSound()
    {

        hurt.Play();
    }

      private  void SetOfFunctionforNpc()
    {
        gameObject.GetComponent<Niearest>().enabled = false;
    }
    
    private void SetOfFunctionforEnemy()
    {
        gameObject.GetComponent<EnemyMoveMent>().enabled = true;
      
    }
    private void SetOnFunctionforEnemy()
    {
        gameObject.GetComponent<EnemyMoveMent>().enabled = false;
      
    }
    void lose()
    {

        gameRegim.Lose();
    }
}
