using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Player : MonoBehaviour
{

    public int fuerzaExtra = 0;
    
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

    public int contador;
    public Text puntuacion;

    private Vector3 myVector3;

    //public GameObject Suelo;

    public bool atack;
    public bool Walk;
    public float impulsG = 10f;
    
    void Start()
    {
        CanJump = false;
        //IsJumping = false;
        //anim = GetComponent<Animator>();

        GameObject lifeBarGameObject = GameObject.Find("LifeBar");
        if (lifeBarGameObject)
        {
            lifeBar = lifeBarGameObject.GetComponent<Image>();
        }


        maxLife = life;
        ChangeLife(0);


        //Suelo = GameObject.FindObjectWithTag("Suelo"); 

    }

    public void Awake()
    {
        //rb = GetComponent<Rigidbody>();
        contador = 0;
        puntuacion.text = " X " + contador;
    }

    private void FixedUpdate()
    {
        if(atack == false)
        {
            transform.Rotate(0, x * Time.deltaTime * SpeedRota, 0);
            transform.Translate(0, 0, y * Time.deltaTime * SpeedMove);
        }

        if (Walk)
        {
            rb.velocity = transform.forward * impulsG;
        }
    }

    void Update()
    {

        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.J) && CanJump && !atack)
        {
            //transform.Traslate(new Vector3.forward * SpeedMove * Time.deltaTime));
            //Debug.Log("gira");
            anim.SetTrigger("Golpeo");
            atack = true;
        }

        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);

       

        if (CanJump == true)
        {
            if (!atack)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    anim.SetBool("Jump", true);
                    rb.AddForce(new Vector3(0, ForceJump, 0), ForceMode.Impulse);
                    //IsJumping = true;
                }
            }
            

            anim.SetBool("Tocosuelo", true);
        }

        else
        {
           
            Fall();
        }
    }

    public void ChangeLife(int value)
    {

        life += value;


        if (life > maxLife)

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

        if (life <= 0)
        {
            SceneManager.LoadScene("SceneLost");
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Spikes"))
        {
            Debug.Log("Golpe de puas");
            ChangeLife(-1);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Golpe de Enemigo");
            ChangeLife(-1);
        }


        if (collision.gameObject.CompareTag("Danger Zone"))
        {
            Debug.Log("Muerte por altura");
            ChangeLife(-5);
        }

    }

    private void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.tag == "Grajea")
        {

            contador = contador + 1;
            //SIEMPRE asociar o si no se borra el script en Awake
            puntuacion.text = " X " + contador;
            Destroy(obj.gameObject);
        }
        
        if (obj.gameObject.CompareTag("Salida"))
        {
            SceneManager.LoadScene("Nivel1");
        }

        if (obj.gameObject.tag == "Life")
        {

          ChangeLife(obj.gameObject.GetComponent<Life>().life);
          Destroy(obj.gameObject);
        }
    }


    public void Fall()
    {
        rb.AddForce(fuerzaExtra * Physics.gravity);
        
        anim.SetBool("Tocosuelo", false);
        anim.SetBool("Jump", false);
    }
    
    public void dejeGolpear()
    {
        atack = false;
        
    }

    public void inpuls()
    {
        Walk = true;
    }

    public void dejoAvanzar()
    {
        Walk = false;
    }
}
