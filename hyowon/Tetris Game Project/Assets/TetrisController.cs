using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisController : MonoBehaviour
{
    private float fTickTime;
    private static int[, ] arr = new int[9, 15];
    void check(){
        Vector3 pos;
        Transform child;
        for(int i = 0; i<4; i++){
            child = this.gameObject.transform.GetChild(i);
            pos = child.transform.position;
            Debug.Log(pos);
            arr[(int)pos.x,(int)pos.y] = 1;
        }
    }
    bool IsMove(){
        Vector3 nextpos;
        Transform child;
        for(int i = 0; i<4; i++){
            child = this.gameObject.transform.GetChild(i);
            nextpos = child.transform.position;
            // 범위를 벗어나는경우
            if(nextpos.x < 0 || 8 < nextpos.x || nextpos.y < 0 )
            {
                return false;
            }
            // 이미 블럭이 있는경우
            else if(arr[(int)nextpos.x ,(int)nextpos.y ] == 1)
            {
                return false;
            }

        }
        return true; 
    }
    // Start is called before the first frame update
    void Start()
    {
        int[,] arr =new int[9,15];
 
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
                check();
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
