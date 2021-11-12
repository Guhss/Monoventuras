using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enamigo : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator Anim;
    public Quaternion angulo;
    public float grado;

    public GameObject target;

    void Start()
    {
        Anim = GetComponent<Animator>();

    }

    void Update()
    {
        Comportamiento_Enemigo();

    }

    public void Comportamiento_Enemigo()
    {
        cronometro += 1 * Time.deltaTime;
        if (cronometro >= 4)
        {
            rutina = Random.Range(0, 2);
            cronometro = 0;
        }
        switch (rutina)
        {
            case 0:
                Anim.SetBool("Walk", false);
                break;


            case 1:
                grado = Random.Range(0, 360);
                angulo = Quaternion.Euler(0, grado, 0);
                rutina++;
                break;


            case 2:
                transform.rotacion = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                Anim.SetBool("Walk", true);
                break;
        }
    }
}
