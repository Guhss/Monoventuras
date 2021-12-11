using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    public PlayerModel model;
    public PlayerController controller;

    // Start is called before the first frame update
    void Start()
    {
        GameObject lifeBarGameObject = GameObject.Find("LifeBar");
        model.lifeBar = lifeBarGameObject.GetComponent<Image>();
    }
    public void Awake()
    {
        model.puntuacion.text = " X " + model.contador;
    }

    private void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.tag == "Grajea")
        {
            model.puntuacion.text = " X " + model.contador;
        }
    }
    }
