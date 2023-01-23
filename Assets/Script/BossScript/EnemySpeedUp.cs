using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpeedUp : MonoBehaviour
{
    [SerializeField]
    private float speed;
    GameObject[] enemy;
    // Start is called before the first frame update

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyMoveMent>().Speed+= speed; 
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Npc"))
        {
            other.gameObject.GetComponent<Health>().TakeDamage(200);
        }
    }
    
}
