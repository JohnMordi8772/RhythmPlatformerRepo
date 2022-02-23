using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoubleChoice : MonoBehaviour
{
    [SerializeField] GameObject firstChoiceBarrier;
    [SerializeField] GameObject secondChoiceBarrier;
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
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            firstChoiceBarrier.SetActive(true);
            MapGeneration.yPosition += 1f;
            triggered = true;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            secondChoiceBarrier.SetActive(false);
            triggered = true;
        }
    }
}

