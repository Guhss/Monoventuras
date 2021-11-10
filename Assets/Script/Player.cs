using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public float SpeedMove = 5.0f;
    public float SpeedRota = 250.0f;

    public Rigidbody rb;
    public float ForceJump = 4f;
    public bool CanJump;
    public bool IsJumping;

    
    public float life;
    public float maxLife;
    public Image lifeBar;

    public Animator anim;
    public float x, y;
    
    void Start()
    {
        CanJump = false;
        IsJumping = false;
        //anim = GetComponent<Animator>();

        GameObject lifeBarGameobject = GameObject.Find("LifeBar");
        if (lifeBarGameobject)
        {
            lifeBar = lifeBarGameobject.GetComponent<Image>();
        }
    }


    private void FixedUpdate()
    {
        transform.Rotate(0, x * Time.deltaTime * SpeedRota, 0);
        transform.Translate(0, 0, y * Time.deltaTime * SpeedMove);
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);

        if (CanJump == true)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                anim.SetBool("Jump", true);
                rb.AddForce(new Vector3(0, ForceJump, 0), ForceMode.Impulse);
                IsJumping = true;                
            }

            if (Input.GetKeyDown(KeyCode.X))
            {

                Debug.Log("gira");
            }

            anim.SetBool("Tocosuelo", true);
        }
        else
        {
            if (IsJumping == true)
            {
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    anim.SetBool("Jump", true);
                    rb.AddForce(new Vector3(0, ForceJump * 2, 0), ForceMode.Impulse);
                    IsJumping = false;
                }
                anim.SetBool("Tocosuelo", true);
            }
            Fall();
        }
    }

    public void ChangeLife(int value)
    {

        life += value;

        if (life <= 0)
        {
            SceneManager.LoadScene("SceneLost");
            Destroy(gameObject);
        }
        else if (life > maxLife)
        {
            life = maxLife;
        }

        if (lifeBar)
        {
            lifeBar.fillAmount = life / maxLife;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Spikes"))
        {
            Debug.Log("Golpe de puas");
            ChangeLife(-1);
        }
    }

    private void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.tag == "Life")
        {

          ChangeLife(obj.gameObject.GetComponent<Life>().life);
          Destroy(obj.gameObject);
        }
    }


    public void Fall()
    {
        anim.SetBool("Tocosuelo", false);
        anim.SetBool("Jump", false);
    }
    
}
