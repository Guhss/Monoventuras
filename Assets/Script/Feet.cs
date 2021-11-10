using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feet : MonoBehaviour
{

    public Player Player; 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        Player.CanJump = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Player.CanJump = false;
    }
}
