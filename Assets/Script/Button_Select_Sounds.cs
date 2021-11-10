using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Select_Sounds : MonoBehaviour
{

    public AudioSource audiosource;
    public AudioClip selected_sfx2;
    public AudioClip button_change;

    
    void Update()
    {
        Button_Selected();
    }


    void Button_Selected()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) ||Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)||Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            audiosource.PlayOneShot(button_change, 1);
        }

        if ((Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Space)))
        {
            audiosource.PlayOneShot(selected_sfx2, 1);
        }
       
    }
}
