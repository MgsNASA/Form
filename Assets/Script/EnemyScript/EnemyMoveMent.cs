using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveMent : MonoBehaviour
{
    [SerializeField]
    private float Scale =3;
    [SerializeField]
    private float MinusScale =-3;
    private GameObject castleObject;
    private Transform Castle;
    [SerializeField]
    public float Speed;
    [SerializeField]
    private float distance;
    public bool Fight;
    private void Start()
    {
        castleObject = GameObject.Find("Castle");
        Castle = GameObject.Find("Castle").transform;
    }

    // Update is called once per frame
    //Vector2.Distance = enemy.transform.position - player.transform.position
    private void Update()
    {
        if (DataHolder.StartGame == true)
        {
            MoveTo();
            Flip();
        }
    }
    private void MoveTo()
    {  if (Fight == false)
        {
            distance = Vector2.Distance(transform.position, Castle.transform.position); //Растояние между обьектом и замком.
            Vector2 direction = Castle.transform.position - transform.position;
            transform.position = Vector2.MoveTowards(this.transform.position, Castle.transform.position, Speed * Time.deltaTime);
        }
    }
    void Flip()
    {
        if (transform.position.x > Castle.position.x)
        {
            transform.localScale = new Vector2(MinusScale, Scale);
        }
        else if (transform.position.x < Castle.position.x)
        {
            transform.localScale = new Vector2(Scale, Scale);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Npc"))
        {
            Castle = collision.GetComponent<Transform>().transform;
            Fight = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Fight = false;
    }

}
