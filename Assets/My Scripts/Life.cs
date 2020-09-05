using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    [SerializeField] private int initialLife = 5;
    private int currentLife;

    [SerializeField]
    private AudioSource damaged;

    [SerializeField]
    private AudioSource dead;

    [SerializeField]
    private AudioSource bkg;

    [SerializeField] Text message;

    // Start is called before the first frame update
    void Start()
    {
        currentLife = initialLife;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentLife <= 0)
        {
            message.text = "GAME OVER";
            dead.Play();
            bkg.Stop();
            Time.timeScale = 0;
        }
    }

    private void OnTriggerEnter(Collider col)
   {
       if(col.tag == "Enemy")
       {
            currentLife -= 1;
            Debug.Log(currentLife);
            damaged.Play();
       }
   }


}
