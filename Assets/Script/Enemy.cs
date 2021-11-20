using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{

    public NavMeshAgent agente;
    public Transform player;
    public LayerMask Suelo, Qplayer;

    // patron
    public Vector3 Caminar;
    bool Distancia;
    public float Rango;

    //ataque
   // public float TimeBetweenAttacks;
    //bool alreadyAttacked;

    //estadisticas 
    public float rangoVision, rangoAtaque;
    public bool playerRangoVision, playerRangoAtaque;


    private void awake()
    {
        player = GameObject.Find("Player").transform;
        agente = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //Rango de ataque 
        playerRangoVision = Physics.CheckSphere(transform.position, rangoVision, Qplayer);
        playerRangoAtaque = Physics.CheckSphere(transform.position, rangoAtaque, Qplayer);

        if (!playerRangoVision && !playerRangoAtaque) Patron();
        if (playerRangoVision && !playerRangoAtaque) Persecucion();
        //if (playerRangoVision && playerRangoAtaque) Ataque();
    }

    private void Patron()
    {
        if (!Distancia) CaminataBusqueda();
    }

    private void CaminataBusqueda()
    {
        float randomZ = Random.Range(-Rango, Rango);
        float randomX = Random.Range(-Rango, Rango);

        Caminar = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(Caminar, -transform.up, 2f, Suelo))
            Distancia = true;
    }

    private void Persecucion()
    {
        agente.SetDestination(player.position);
    }

    private void Ataque()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

  
}
