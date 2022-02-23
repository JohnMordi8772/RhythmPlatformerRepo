using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TylerArrowBehaviour : MonoBehaviour
{
    public int tempo = 120; //bpm
    public float moveSpeed;
    void Start()
    {
       
    }


    void Update()
    {
        moveSpeed = tempo / 7.5f;

        float xMove = -1;

        Vector2 NewPos = transform.position;

        NewPos.x += xMove * Time.deltaTime * moveSpeed;

        transform.position = NewPos;

        if(transform.position.x <= -16)
        {
            Destroy(gameObject);
        }
    }
}
