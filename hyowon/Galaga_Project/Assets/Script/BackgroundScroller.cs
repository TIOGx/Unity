using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollspeed;
    public Transform[] backgrounds;
    float yScreenSize;
    float topPosY = 0f;
    float bottomPosY = 0f;
    void Start()
    {
        yScreenSize = Camera.main.orthographicSize * 2;
        bottomPosY = -yScreenSize * backgrounds.Length; // - 40일때 40으로 끌어올리자
         topPosY = - bottomPosY;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < backgrounds.Length ; i ++){
            backgrounds[i].position += new Vector3(0, -scrollspeed, 0) * Time.deltaTime;
            if(backgrounds[i].position.y < bottomPosY){
                Vector3 nextPos = backgrounds[i].position;
                nextPos = new Vector3(nextPos.x, topPosY, nextPos.z);
                backgrounds[i].position = nextPos;
            }
        }
    }
}