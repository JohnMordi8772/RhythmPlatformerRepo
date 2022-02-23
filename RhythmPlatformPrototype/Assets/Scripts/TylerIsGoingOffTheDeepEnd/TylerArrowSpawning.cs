using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TylerArrowSpawning : MonoBehaviour
{
   
    
    public GameObject ArrowSpawner;
    public TylerGameController tgc;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnArrow", 4, (30/tgc.bpm));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnArrow()
    {
        
        
            Instantiate(ArrowSpawner, new Vector2(15.8f,-1.6f), Quaternion.identity);
        tgc.i++;
        
        
    }
}
