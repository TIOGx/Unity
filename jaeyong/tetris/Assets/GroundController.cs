using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    ObjectController player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find(ObjectController).GetComponent<ObjectController>();
    }
    void checkrow()
    {
        for(int i = 0; i < 15; i++)
        {
            for(int j = 0; j<9; j++)
            {
                player.visit[]
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
