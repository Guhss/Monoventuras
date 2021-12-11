using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public PlayerModel model;

    void Start()
    {
        model.speedTimer = 0;
        model.boostedSpeed = false;

        model.CanJump = false;

        model.maxLife = model.life;
        ChangeLife(0);
    }

    public void Awake()
    {
        model.contador = 0;
    }

    private void FixedUpdate()
    {
        transform.Rotate(0, model.x * Time.deltaTime * model.SpeedRota, 0);
        transform.Translate(0, 0, model.y * Time.deltaTime * model.SpeedMove);
    }

    void Update()
    {
        model.x = Input.GetAxis("Horizontal");
        model.y = Input.GetAxis("Vertical");

        model.anim.SetFloat("VelX", model.x);
        model.anim.SetFloat("VelY", model.y);

        if (model.boostedSpeed)
        {
            model.speedTimer += Time.deltaTime;
            if (model.speedTimer >= 3)
            {
                model.SpeedMove = 5;
                model.speedTimer = 0;
                model.boostedSpeed = false;
            }
        }

        if (model.CanJump == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                model.anim.SetBool("Jump", true);
                model.rb.AddForce(new Vector3(0, model.ForceJump, 0), ForceMode.Impulse);
            }
            model.anim.SetBool("Tocosuelo", true);
        }

        else
        {
            Fall();
        }
    }

    public void ChangeLife(int value)
    {

        model.life += value;

        if (model.life > model.maxLife)

        {
            model.life = model.maxLife;
        }

        if (model.lifeBar)
        {
            model.lifeBar.fillAmount = model.life / model.maxLife;
        }

        if (model.life <= 0)
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

            model.contador = model.contador + 1;
            //SIEMPRE asociar o si no se borra el script en Awake
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

        if (obj.gameObject.tag == "SpeedBoost")
        {

            model.boostedSpeed = true;
            model.SpeedMove = 10;
            Destroy(obj.gameObject);
        }

    }

    public void Fall()
    {
        model.rb.AddForce(model.fuerzaExtra * Physics.gravity);
        model.anim.SetBool("Tocosuelo", false);
        model.anim.SetBool("Jump", false);
    }
}
