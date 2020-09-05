using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NeedleAttack : MonoBehaviour
{
    public AudioSource dead;
    private AudioSource bgm;
    private GameObject gameManager;
    private GameObject canvas;
    private Text message;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameController");
        canvas = GameObject.FindWithTag("UI");
        bgm = gameManager.GetComponent<AudioSource>();
        message = canvas.transform.GetChild(0).gameObject.GetComponent<Text>();
    }

    private void OnTriggerEnter(Collider col)
   {
       if(col.gameObject.tag == "MainCamera")
       {
           dead.Play();
           bgm.Stop();
            message.text = "You Are Dead...";
            gameManager.GetComponent<Fall>().ratio = 0.0f;
       }
   }

    // Update is called once per frame
    void Update()
    {
        
    }
}
