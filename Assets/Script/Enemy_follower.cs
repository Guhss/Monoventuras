using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy_follower : MonoBehaviour
{
    public Transform Player;
    public Rigidbody2D rb2d;
    public float speed;
    public string animation_name;
    public bool use_animation_name;
    public float vx;
    public Animator animator;
   

    public float max_distance;
    public Vector3 dist_diff;
   
   
    public bool follow_player;
    public bool facingRight=false;
    

    private void Start()
    {
        GameObject playerGameObject = GameObject.Find("Player");
        if (playerGameObject)
        {
            Player = playerGameObject.transform;
        }
        rb2d = GetComponent<Rigidbody2D>();

            
    }


    private void Update()
    {
        Follow();

        CheckDistance();

        dist_diff = Player.transform.position - transform.position;

        if (Player.transform.position.x < gameObject.transform.position.x && facingRight)
        {
            Flip();
        }


        if (Player.transform.position.x > gameObject.transform.position.x && !facingRight)
        {
            Flip();
        }
    }


    void Follow()
    {
        if (Player == false)
        {
            SceneManager.LoadScene("SceneLost");
            Destroy(gameObject);
            return;
        }


        if (follow_player)
        {

            Vector3 followXonly = new Vector3(
                                    Player.transform.position.x,
                                    transform.position.y,
                                    transform.position.z);

            transform.position = Vector3.MoveTowards(
                                        transform.position,
                                        followXonly,
                                        speed * Time.deltaTime);
            Vector3 scale = transform.localScale;
          

        }

    }
    

        void CheckDistance()
    {
        if (Player)
        {
            if (Vector2.Distance(Player.position, transform.position) >= max_distance)
            {
                follow_player = false;

            }
            else
            {
                follow_player = true;
                if (animator&&use_animation_name)
                {
                    
                    gameObject.GetComponent<Animator>().SetFloat(animation_name, 5);

                    

                }

                
            }
        }
    
    }

    void Flip()
    {
        
        facingRight = !facingRight;
        Vector3 tmpScale = gameObject.transform.localScale;
        tmpScale.x *= -1;
        gameObject.transform.localScale = tmpScale;
    }





}
