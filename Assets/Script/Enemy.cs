using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float speed;
    public Vector2 direction;
    public float timer;
    public float maxTimer;
    public float life;
    public bool OFF;
    

    public Animator ani;

    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        Move();
        ChangeDirection();

    }



    void ChangeDirection()
    {
        timer += Time.deltaTime;
        if (timer >= maxTimer)
        {
            direction *= -1;
            timer = 0;
        }
    }

    void Move()
    {
        if (OFF == false)
        {
            rb2d.velocity = direction * speed;
        }

    }

       
}
