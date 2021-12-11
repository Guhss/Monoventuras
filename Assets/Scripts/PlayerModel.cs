using UnityEngine;
using UnityEngine.UI;

public class PlayerModel : MonoBehaviour
{
    public int fuerzaExtra = 2;

    public float SpeedMove = 5.0f;
    public float SpeedRota = 250.0f;


    public bool boostedSpeed;
    public float speedTimer;

    public Rigidbody rb;
    public float ForceJump = 4f;
    public bool CanJump;
    public bool IsJumping;


    public float life;
    public float maxLife = 3;
    public Image lifeBar;

    public Animator anim;
    public float x, y;

    public int contador;
    public Text puntuacion;

    private Vector3 myVector3;

}
