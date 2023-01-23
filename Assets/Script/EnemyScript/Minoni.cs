using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minoni : MonoBehaviour
{
    [SerializeField]
    private Transform npcplace;
    private Animator animator;
    [SerializeField]
    private GameObject [] Minion;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        InvokeRepeating("AnimatorToCreate", 3,3);
    }

  
    void AnimatorToCreate()
    {
        animator.SetTrigger("Ability");
    }
   public  void CreateNpc()
    {
       
            Instantiate(Minion[Random.Range(0,Minion.Length)], npcplace);
        
    }
}
