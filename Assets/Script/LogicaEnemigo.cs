using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LogicaEnemigo : MonoBehaviour
{

    private GameObject target;
    private NavMeshAgent agente;
    private Vida vida;
    private Animator anim;
    private collider coll;
    private Vida Life;
    //private LogicaJugador Player;
    public bool vida0 = false;
    public bool estaAtacando = false;
    public float Speed = 2.0f;
    public float Rotacion = 120;
    public float Daño = 25;
    public transform other;
    public bool mirando;
    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.find("Player");
        Life = target.GetComponent<Vida>;
        if(Life== null)
        {
            throw new System.Exception("el objeto no tiene vida");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
