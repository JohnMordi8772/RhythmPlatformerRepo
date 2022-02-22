using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TylerSceneMonitorBehaviour : MonoBehaviour
{

    bool playerWithin, hit;
    KeyCode choice;

    public GameObject upArrow, downArrow, leftArrow, rightArrow, spike;

    //[SerializeField] Image placement;
    [SerializeField] List<Sprite> arrows;

    public GameObject GameController;
    public TylerGameController gc;
    public int arrow;

    // Start is called before the first frame update
    void Awake()
    {
        GameController = GameObject.Find("GameController");
        gc = GameController.GetComponent<TylerGameController>();

        arrow = gc.currentArrow;

        playerWithin = false;
        hit = false;

        //the maximum value on a Random.Range is exclusive.
        switch (gc.currentArrow)
        {
            case 0:
                spike.SetActive(true);
                break;
            case 1:
                gc.noArrow = false;
                choice = KeyCode.UpArrow;
                //placement.sprite = arrows[0];
                upArrow.SetActive(true);
                break;
            case 2:
                gc.noArrow = false;
                choice = KeyCode.DownArrow;
                //placement.sprite = arrows[1];
                downArrow.SetActive(true);
                break;
            case 3:
                gc.noArrow = false;
                choice = KeyCode.LeftArrow;
                ///placement.sprite = arrows[2];
                leftArrow.SetActive(true);
                break;
            case 4:
                gc.noArrow = false;
                choice = KeyCode.RightArrow;
                //placement.sprite = arrows[3];
                rightArrow.SetActive(true);
                break;
            case 5:
                Destroy(gameObject);
                break;
            default:
                Destroy(gameObject);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerWithin && !hit)
        {
            if (Input.GetKeyDown(choice))
            {
                gc.Monitoring(true);
                hit = true;
                Debug.Log("Correct, you're great");
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                gc.Monitoring(false);
                hit = true;
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
        if (hit != true)
        {
            gc.Monitoring(false);
        }
    }
}
