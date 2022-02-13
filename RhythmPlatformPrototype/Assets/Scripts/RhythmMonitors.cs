using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RhythmMonitors : MonoBehaviour
{
    bool playerWithin, hitCorrectly, hitIncorrectly;
    KeyCode choice;
    [SerializeField]Image placement;
    [SerializeField]List<Sprite> arrows;
    
    // Start is called before the first frame update
    void Start()
    {
        playerWithin = false;
        hitCorrectly = false;
        hitIncorrectly = false;
        switch(Random.Range(1,4))
        {
            case 1:
                choice = KeyCode.UpArrow;
                placement.sprite = arrows[0];
                break;
            case 2:
                choice = KeyCode.DownArrow;
                placement.sprite = arrows[1];
                break;
            case 3:
                choice = KeyCode.LeftArrow;
                placement.sprite = arrows[2];
                break;
            case 4:
                choice = KeyCode.RightArrow;
                placement.sprite = arrows[3];
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
