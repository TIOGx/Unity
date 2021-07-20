using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TetrisController : MonoBehaviour
{
    private float fTickTime;
    private static Transform [, ] arr = new Transform [20, 10];

    void RemoveRow(){
        bool flag;
        for(int i =0; i <20;i++){
            flag = true;
            for(int j =0;j<10;j++){
                if(arr[i,j] == null){
                    flag = false;
                    break;
                }
            }
            if(flag){
                GameObject.Find("Timer").GetComponent<Timer>().LimitTime += 5;
                GameObject.Find("ScoreBoard").GetComponent<ScoreBoard>().Score += 1;
                for(int j= 0;j<10;j++){
                    Destroy(arr[i,j].gameObject);
                }
                for (int k = i;k<19;k++){
                    for(int j= 0;j<10;j++){
                        arr[k,j] = arr[k+1,j];
                        arr[k+1,j] = null;
                        if(arr[k,j] != null){
                            arr[k,j].transform.position += new Vector3(0,-1,0);
                        }
                    }
                }
                i -= 1;
            }

        }
    }
    
    void Hold(){
        Vector3 pos;
        Transform child;
        for(int i = 0; i<4; i++){
            child = transform.GetChild(i);
            pos = child.transform.position;
            arr[(int)Math.Round(pos.y),(int)Math.Round(pos.x)] = child ;
        }
    }
    bool IsMove(){
        Vector3 nextpos;
        Transform child;
        for(int i = 0; i<4; i++){
            child = transform.GetChild(i);
            nextpos = child.transform.position;
            // 범위를 벗어나는경우
            if((int)Math.Round(nextpos.x) < 0 || 9 < (int)Math.Round(nextpos.x) || (int)Math.Round(nextpos.y) < 0 )
            {
                Debug.Log("범위 벗어나");
                return false;
            }
            // 이미 블럭이 있는경우
            if(arr[(int)Math.Round(nextpos.y),(int)Math.Round(nextpos.x)] != null)
            {
                return false;
            }

        }
        return true; 
    }
    // Start is called before the first frame update
    void Start()
    {
        Transform [,] arr = new Transform [20,10];
 
    }
    // Update is called once per frame
    void Update()
    {
        fTickTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1,0,0);
            if(!IsMove()){
                transform.position += new Vector3(1,0,0);
            }
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1,0,0);
            if(!IsMove()){
                transform.position += new Vector3(-1,0,0);
            }
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0,-1,0);
            if(!IsMove()){
                transform.position += new Vector3(0,1,0);
                
            }
            else{
                fTickTime = 0;
            }
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            transform.RotateAround(transform.position,new Vector3(0,0,1), 90);
            if(!IsMove()){
                transform.RotateAround(transform.position,new Vector3(0,0,1), -90);
            }
        }
        
        if(fTickTime >= 1f){
            transform.position += new Vector3(0,-1,0);
            if(!IsMove()){
                transform.position += new Vector3(0,1,0);
                // 여기서 객체를 고정해주고 다음 프리팹 소환하자
                // 고정 및 좌표저장
                gameObject.GetComponent<TetrisController>().enabled = false;
                Hold();
                RemoveRow();
                // 소환
                GameObject.Find("Prefab").GetComponent<TetrisCreator>().CreatBlock();
                fTickTime = 0;
      
            }
        else{
            fTickTime = 0;
        }
       }
    }

}
