using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TripleChoice: MonoBehaviour
{
    [SerializeField] GameObject upperBarrier, middleBarrier, lowerBarrier;
    KeyCode upperChoice = KeyCode.UpArrow;
    KeyCode lowerChoice = KeyCode.DownArrow;

    bool triggered = false;

    [SerializeField] Image[] images;
    [SerializeField] Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (triggered)
            return;
        if (Input.GetKeyDown(upperChoice))
        {
            upperBarrier.SetActive(true);
            MapGeneration.yPosition += 5f;
            triggered = true;
        }
        else if (Input.GetKeyDown(lowerChoice))
        {
            lowerBarrier.SetActive(false);
            MapGeneration.yPosition -= 5f;
            triggered = true;
        }
        else
        {
            middleBarrier.SetActive(false);
            triggered = true;
        }
    }
}
