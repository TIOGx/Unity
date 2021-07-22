using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjboxController : MonoBehaviour
{
    [SerializeField]
    private GameObject tile;
    [SerializeField]
    private GameObject objbox;
    [SerializeField]
    private GameObject ground;
    private float topy = 17f;
    private float topx = 8f;
    private float maxtimer = 0.7f;
    private float timer = 0.0f;
    private bool bar = false;
    private bool clear = false;
    private int r = -1;
    private bool[,] visit = new bool[9, 16];

    // -4.74~y~4.74 , -2.56~x~2.56, �� y��ǥ�� �� �� �ִ� Ÿ�� ���� 11��
    // �� ĭ�� �����ϴ� ���� ) 0.5
    void visitinitialize(){
        for(int i=0;i<9;i++){
            for(int j=0;j<16;j++){
                visit[i,j] = false;
            }
        }
    }
//  void checkvisit(){
//      for(int i=0;i<ground.transform.childCount;i++){
//          Transform col = ground.transform.GetChild(i);
//          Debug.Log("col: " + col);
//          for(int j=0;j<col.childCount;j++){
//              Transform row = col.GetChild(j);
//              int vi = int.Parse(row.name);
//              visit[vi, i] = true;
//          }
//      }
//  }
    void checkclean(int idx){
        for(int i=idx+1;i<ground.transform.childCount;i++){
            Transform col = ground.transform.Find(i.ToString());
            Transform colu = ground.transform.Find((i-1).ToString());
            while(col.childCount > 0){
                Transform tile = col.GetChild(0);
                visit[(int)(Mathf.Round(tile.position.x)), i] = false;
                visit[(int)(Mathf.Round(tile.position.x)), i-1] = true;
                tile.parent = colu;
                Debug.Log("True x좌표 :" + (int)(Mathf.Round(tile.position.x)) + " y좌표: " + (i-1));
                tile.transform.localPosition = new Vector3(tile.transform.position.x, 0, 0);
            }
            col.DetachChildren();
        }
    }
    void checkground()
    {
        for(int j = 0; j < ground.transform.childCount; j++)
        {
            Transform col = ground.transform.GetChild(j);
            if(col.childCount == 9)
            {
                Debug.Log("Checkground! col num : " + int.Parse(col.name));
                foreach (Transform tile in col)
                {
                    Destroy(tile.gameObject);
                    
                }
                col.DetachChildren();
                for(int i = 0; i < 9; i++)
                {
                    Debug.Log("False : x : " + i + "col_name ,y :" + int.Parse(col.name));
                    visit[i, int.Parse(col.name)] = false;
                }
                checkclean(int.Parse(col.name));
                j--;
            }
        }
    }
    bool checkerror()
    {
        for(int i=0;i<4;i++){
            if(objbox.transform.childCount == 4)
            {
                Transform tf = objbox.transform.GetChild(i).transform;
                int x = (int)Mathf.Round(tf.position.x);
                int y = (int)Mathf.Round(tf.position.y);
                if (x < 0 || x > topx)
                {
                    Debug.Log("범위 벗어남");
                    return true;
                }
                if (y < 0 || y > topy)
                {
                    Debug.Log("범위 벗어남2");
                    return true;
                }
                if (visit[x, y])
                {
                    Debug.Log("블러기 존재함");
                    return true;
                }
            }
            else
            {
                Debug.Log("말도안되는 오류");
            }
        }
        return false;
    }
    void Gobackground()
    {
        for (int i = 0; i < 4; i++)
        {
            if (objbox.transform.childCount > 0)
            {
                Transform tf = objbox.transform.GetChild(0).transform; // 차일드의 개수가 3개로 바뀌거든? 0,1,2,3 이였던게
                // 1,2,3 만 남게돼 0이 
                Vector3 pos = tf.transform.position;
                int x = (int)Mathf.Round(pos.x);
                int y = (int)Mathf.Round(pos.y);
                visit[x, y] = true;
                tf.name = x.ToString();
                tf.parent = ground.transform.Find(y.ToString()); 
            }

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        int m = 16;
        for (int i = 0; i < m; i++)
        {
            GameObject col = (GameObject) new GameObject((i).ToString());
            col.transform.position = new Vector3(0, i, 0);
            col.transform.SetParent(ground.transform, true);
        }
        visitinitialize();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > maxtimer)
        {
            timer = 0;
            objbox.transform.Translate(0, -1f, 0, Space.World);
            if(checkerror()){
                objbox.transform.Translate(0, 1f, 0, Space.World);
                Gobackground();
                checkground();
                GameObject.FindWithTag("Generator").GetComponent<TileGenerator>().CreateTet();
            }
            
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && r != 3)
        {
            if (r == 1 && bar == false)
            {
                objbox.transform.RotateAround(objbox.transform.position, new Vector3(0, 0, 1), 90f);
                bar = true;
                if(checkerror()){
                    objbox.transform.RotateAround(objbox.transform.position, new Vector3(0, 0, 1), -90f);
                    bar = false;
                }
            }
            if (r == 1 && bar == true)
            {
                objbox.transform.RotateAround(objbox.transform.position, new Vector3(0, 0, 1), -90f);
                bar = false;
                if(checkerror()){
                    objbox.transform.RotateAround(objbox.transform.position, new Vector3(0, 0, 1), 90f);
                    bar = true;
                }
            }
            objbox.transform.RotateAround(objbox.transform.position, new Vector3(0, 0, 1), 90f);
            if (checkerror())
            {
                objbox.transform.RotateAround(objbox.transform.position, new Vector3(0, 0, 1), -90f);
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            objbox.transform.Translate(-1f, 0, 0, Space.World);
            if(checkerror()){
                objbox.transform.Translate(1f, 0, 0, Space.World);
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            objbox.transform.Translate(1f, 0, 0, Space.World);
            if(checkerror()){
                objbox.transform.Translate(-1f, 0, 0, Space.World);
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            objbox.transform.Translate(0, -1f, 0, Space.World);
            if(checkerror()){
                objbox.transform.Translate(0, 1f, 0, Space.World);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            while (!checkerror())
            {
                objbox.transform.Translate(0, -1f, 0, Space.World);
            }
            objbox.transform.Translate(0, 1f, 0, Space.World);
        }
    }
}
