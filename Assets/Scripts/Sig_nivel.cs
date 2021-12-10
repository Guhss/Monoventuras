using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sig_nivel : MonoBehaviour
{

    public int sigEscenea;


    private void OnTriggerEnter(Collider obj)
    {
        if(obj.tag == "player")
        {
            SceneManager.LoadScene("Nivel1");
        }
    }
}
