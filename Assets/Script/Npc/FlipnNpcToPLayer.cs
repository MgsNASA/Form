using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipnNpcToPLayer : MonoBehaviour
{
    [SerializeField]
    private Transform Enemy;
    private void Update()
    {
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