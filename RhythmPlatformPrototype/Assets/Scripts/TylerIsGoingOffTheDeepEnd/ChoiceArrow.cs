using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceArrow : MonoBehaviour
{
    public GameObject GameController;
    public TylerGameController tgc;
    public bool gotInput;
    public bool playerWithin;
    // Start is called before the first frame update
    void Awake()
    {
        gotInput = false;
        playerWithin = false;
        GameController = GameObject.Find("GameController");
        tgc = GameController.GetComponent<TylerGameController>();
    }

    // Update is called once per frame
    void Update()
    {
       if(playerWithin == true)
        {
            if (gotInput == false)
            {
                if (Input.GetKeyDown("down"))
                {
                    Time.timeScale = .9f;
                    tgc.bpm = 90;
                    gotInput = true;

                }
                else if (Input.GetKeyDown("up"))
                {
                    Time.timeScale = 1.2f;
                    tgc.bpm = 120;
                    gotInput = true;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerWithin = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        
        if(gotInput == false)
        {
            Time.timeScale = 1.0f;
            tgc.bpm = 100;
        }

        playerWithin = false;

    }
}
