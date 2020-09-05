using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fall : MonoBehaviour
{

    [SerializeField] Vector3 diff = 0.1f * Vector3.down;
    [SerializeField] float startTime = 20f;

    public float ratio = 1.0f;

    public GameObject generators;
    public Transform needles;

    [SerializeField]
    private AudioSource audio;

    private float timer = 0f;
    private bool active = false;

    [SerializeField] int switchNum = 4;
    public int switches;

    [SerializeField] GameObject initialMessage;

    // Start is called before the first frame update
    void Start()
    {
        switches  = switchNum;
    }

    void RandomSet()
    {
        Debug.Log("RandomSet");
        List<int> numbers = new List<int>();
        int count = 0;

    for(int i = 0; i < needles.childCount; i++)
        {
            numbers.Add(i);
        }

    while (count < switchNum) {
 
            int index = Random.Range(0, numbers.Count);
            int num = numbers[index];

            needles.GetChild(num).GetChild(1).gameObject.SetActive(false);
            needles.GetChild(num).GetChild(2).gameObject.SetActive(true);
            
            numbers.RemoveAt(index);
            count += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {   
        if(timer < startTime)
        {
            timer += Time.deltaTime;
            Debug.Log(timer);
        }
        else
        {
            if(!active)
            {
                active = true;
                audio.Play();
                generators.SetActive(false);
                RandomSet();
                initialMessage.SetActive(false);
                foreach (Transform needle in needles)
                {
                    needle.gameObject.SetActive(true);
                }
            }
            else
            {
                foreach (Transform needle in needles)
                {
                    needle.Translate(ratio * diff);
                }
            }
                
        }
        

    }

}
