using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackPlayerTestiing : MonoBehaviour
{
    float x, y;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        y = Input.GetAxisRaw("Vertical");
        x = Input.GetAxisRaw("Horizontal");
        transform.Translate(new Vector3(x, y, 0) * 5 * Time.deltaTime);
    }
}
