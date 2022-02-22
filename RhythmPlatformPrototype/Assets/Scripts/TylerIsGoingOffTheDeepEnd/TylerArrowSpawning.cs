using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TylerArrowSpawning : MonoBehaviour
{
    //THIS SCRIPT IS CURRENTLY UNUSED
    
    
    public GameObject ArrowSpawner;
    public TylerGameController tgc;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnArrow", 4, .25f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnArrow()
    {
        
        
            Instantiate(ArrowSpawner, new Vector2(15.8f,0), Quaternion.identity);
        
        
    }
}
