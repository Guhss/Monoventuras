using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{
    public bool active;
    Canvas pause;
    public GameObject pauseContainer;
    public AudioClip pause_sfx;
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        pauseContainer.SetActive(false);
        pause = GetComponent<Canvas>();
        pause.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            //audioSource.PlayOneShot(pause_sfx);
            active = !active;
            pause.enabled = active;
            pauseContainer.SetActive(active);
            Time.timeScale = (active) ? 0 : 1f;
        }
    }
}
