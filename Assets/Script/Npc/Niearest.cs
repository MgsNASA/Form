using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Niearest : MonoBehaviour
{
    Vector3 position;
    GameObject [] spawnToPosition;
    GameObject[] enemy;
    GameObject closet;
    public string nearest;
    public Transform transformEnemy;
    [SerializeField]
    private Transform Target;
    [SerializeField]
    private float Speed;
    [SerializeField]
    private float distance = 1;
    [SerializeField]
    private string FindObject;
    [SerializeField]
    private bool Fight = false;
    private Animator animator;
    private Health health;
    [SerializeField]
    private int countToAtack;
    [SerializeField]
    private Transform transformCastle;
    [SerializeField]
    private AudioSource batleSound;
    // Start is called before the first frame update
    private void Start()
    {
        spawnToPosition = GameObject.FindGameObjectsWithTag("Position");
        transformCastle = GameObject.Find("Castle").GetComponent<Transform>();
        animator = GetComponent<Animator>();
        position=spawnToPosition[Random.Range(0, spawnToPosition.Length)].transform.position;
    }
    void Find()
    {
        enemy = GameObject.FindGameObjectsWithTag(FindObject);
    }
   public GameObject FindClosectEnemy()
    {
        float distance = Mathf.Infinity;
         
        foreach (GameObject go in enemy)
        {
            Vector3 diff = go.transform.position - position;
            float cutDistance = diff.sqrMagnitude;
            if (cutDistance < distance)
            {
                transformEnemy = go.transform;
                closet = go;
                distance = cutDistance;
            }
        
        
        }
        return closet;
    
    }
    private void Update()
    {
        if (DataHolder.StartGame==true)
        {
            Find();
            nearest = FindClosectEnemy().name;
            MoveToTransform();
            Flip();
        }
    }
    void MoveToTransform()
    {
        if (Fight==false)
        {
            animator.SetBool("Run",true);
            distance = Vector2.Distance(transform.position, transformEnemy.transform.position); //Растояние между обьектом и врагом
            Vector2 direction = transformEnemy.transform.position - transform.position;
            transform.position = Vector2.MoveTowards(this.transform.position, transformEnemy.transform.position, Speed * Time.deltaTime);
        }
    }
    private void Flip()
    {
        if (transform.position.x > transformEnemy.transform.position.x)
        {
            transform.localScale = new Vector2(-3, 3);
        }
        else if (transform.position.x < transformEnemy.transform.position.x)
        {
            transform.localScale = new Vector2(3, 3);
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            animator.SetBool("Run", false);
            Fight = true;
            health= collision.GetComponent<Health>();
            animator.SetTrigger("Atack");


        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Fight = false;
    }
    public void TakeDamage()
    {
        health.TakeDamage(countToAtack);
        
    }
    private void sound()
    {
        batleSound.Play();

    }

}
