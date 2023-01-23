using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMove : MonoBehaviour
{
    
    [SerializeField]
    private Transform Enemy;
    [SerializeField]
    private float Speed;
    [SerializeField]
    private float distance;
    // Start is called before the first frame update
    private Niearest niearest;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, Enemy.transform.position); //Растояние между обьектом и врагом
        Vector2 direction = Enemy.transform.position - transform.position;
        transform.position = Vector2.MoveTowards(this.transform.position, Enemy.transform.position, Speed * Time.deltaTime);
        Flip();
        
    }


    private void Flip()
    {
        if (transform.position.x > Enemy.position.x)
        {
            transform.localScale = new Vector2(-3, 3);
        }
        else if (transform.position.x < Enemy.position.x)
        {
            transform.localScale = new Vector2(3, 3);
        }

    }
}
