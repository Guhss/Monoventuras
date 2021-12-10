using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    private float timer = 99f;
    public Text timerText;
    public float maxTimer;
    public Image timerImage;

    void Start()
    {
        GameObject timerTextGameObject = GameObject.Find("Timer Text");
        if (timerTextGameObject)
        {
            timerText = timerTextGameObject.GetComponent<Text>();
        }

        GameObject timerImageGameObject = GameObject.Find("Timer Image");
        if(timerImageGameObject)
        {
            timerImage = timerImageGameObject.GetComponent<Image>();
        }

        maxTimer = timer;
    }

    void Update()
    {
        Timer();
    }

    void Timer()
    {
        timer -= Time.deltaTime;
        if(timerText)
        {
            timerText.text = " " + timer;
        }

        if(timerImage)
        {
            timerImage.fillAmount = timer / maxTimer;
        }

        if(timer<=0)
        {
            SceneManager.LoadScene("SceneLost");
        }
    }

}
