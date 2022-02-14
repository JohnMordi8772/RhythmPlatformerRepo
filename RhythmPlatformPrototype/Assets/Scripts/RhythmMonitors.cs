using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RhythmMonitors : MonoBehaviour
{
    bool playerWithin, hitCorrectly, hitIncorrectly;
    KeyCode choice;

    public GameObject upArrow, downArrow, leftArrow, rightArrow;

    [SerializeField]Image placement;
    [SerializeField]List<Sprite> arrows;

    
    // Start is called before the first frame update
    void Awake()
    {
        playerWithin = false;
        hitCorrectly = false;
        hitIncorrectly = false;

        //the maximum value on a Random.Range is exclusive.
        switch(Random.Range(1,5))
        {
            case 1:
                choice = KeyCode.UpArrow;
                //placement.sprite = arrows[0];
                upArrow.SetActive(true); 
                break;
            case 2:
                choice = KeyCode.DownArrow;
                //placement.sprite = arrows[1];
                downArrow.SetActive(true);
                break;
            case 3:
                choice = KeyCode.LeftArrow;
                //placement.sprite = arrows[2];
                leftArrow.SetActive(true);
                break;
            case 4:
                choice = KeyCode.RightArrow;
                //placement.sprite = arrows[3];
                rightArrow.SetActive(true);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerWithin)
        {
            if(Input.GetKeyDown(choice) && !hitCorrectly && !hitIncorrectly)
            {
                hitCorrectly = true;
                Debug.Log("Correct, you're great");
            }
            else if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                hitIncorrectly = true;
                Debug.Log("Wrong, you suck");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerWithin = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerWithin = false;
    }
}
