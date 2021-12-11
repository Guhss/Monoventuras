using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feet : MonoBehaviour
{

    public PlayerModel model; 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        model.CanJump = true;
    }

    private void OnTriggerExit(Collider other)
    {
        model.CanJump = false;
    }
}
