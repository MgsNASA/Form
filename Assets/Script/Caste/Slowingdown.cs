using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slowingdown : MonoBehaviour
{
    public float SlowdownSpeed = 1;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyMoveMent>().Speed -= SlowdownSpeed;
        }
    }
}
