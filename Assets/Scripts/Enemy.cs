using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    public NavMeshAgent agente;
    public Transform player;
    private LayerMask Suelo, qPlayer;

    // patrol
    public Vector3 caminar;
    bool flgCamino;
    public float rangoCaminar;

    //ataque
    //public float tiempoEntreAtaque;
    //bool flgAtacado;

    //estados
    public float rangovision, rangoAtaque;
    public bool flgPlayerRangoVision, flgPlayerRangoAtaque;


    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agente = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void Update()
    {
        //revisar rangos
        qPlayer = LayerMask.GetMask("Player");
        flgPlayerRangoVision = Physics.CheckSphere(transform.position, rangovision, qPlayer);
        flgPlayerRangoAtaque = Physics.CheckSphere(transform.position, rangoAtaque, qPlayer);

        if (!flgPlayerRangoVision && !flgPlayerRangoAtaque) Patrullar();
        if (flgPlayerRangoVision && !flgPlayerRangoAtaque) Persecucion();
        if (flgPlayerRangoVision && flgPlayerRangoAtaque) Ataque();
    }

    private void Patrullar()
    {
        if (!flgCamino) BuscarCamino();

        if (flgCamino) agente.SetDestination(caminar);

        Vector3 distancia = transform.position - caminar;

        //punto de caminita alcanzado
        if (distancia.magnitude < 1f)
            flgCamino = false;
    }

    private void BuscarCamino()
    {
        float randomZ = Random.Range(-rangoCaminar, rangoCaminar);
        float randomX = Random.Range(-rangoCaminar, rangoCaminar);

        caminar = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        Suelo = LayerMask.GetMask("Suelo");
        if (Physics.Raycast(caminar, -transform.up, 2f, Suelo))
        {
            flgCamino = true;
        }
    }

    private void Persecucion()
    {
        agente.SetDestination(player.position);
        agente.SetDestination(new Vector3(player.position.x, player.position.y, player.position.z));
    }

    private void Ataque()
    {
        Debug.Log("Ataca el enemigo");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

  
}
