using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    
    [SerializeField] float currentHealth = 1.0f;
    private GameObject gameManager;
    private AudioSource bgm;
    private GameObject canvas;
    private Text message;

    public void Start()
    {
        gameManager = GameObject.FindWithTag("GameController");
        bgm = gameManager.GetComponent<AudioSource>();
        canvas = GameObject.FindWithTag("UI");
        message = canvas.transform.GetChild(0).gameObject.GetComponent<Text>();
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        
        if(currentHealth <= 0f)
        {
            Destroy(this.gameObject);
            gameManager.GetComponent<Fall>().switches -= 1;

            if(gameManager.GetComponent<Fall>().switches <= 0 && gameManager.GetComponent<Fall>().ratio != 0.0f)
            {
                gameManager.GetComponent<Fall>().ratio = -1.5f;
                bgm.Stop();
                message.text = "Survive!!";

            }
        }
    }
}