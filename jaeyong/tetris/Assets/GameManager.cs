using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private bool[,] visit = new bool[11,30];
    [SerializeField]
    private GameObject tile;
    private GameObject obj;
    private float timer = 0.0f;
    private float maxtimer = 1.0f;
    private int x = 0;
    private int y = 0;
    private int cnt = 0;
    // Start is called before the first frame update
    void Start()
    {
        obj = Instantiate(tile, new Vector2(0,4), Quaternion.identity);
        x = 5;
        y = 10;
        for(int i = 0; i < 11; i++)
        {
            for(int j = 0; j < 30; j++)
            {
                visit[i, j] = false;
            }
            visit[i, 0] = true;
        }
    }
    void sync()
    {
        visit[x, y] = true;
        Debug.Log("x : " + x + " y : " + y);
        obj = Instantiate(tile, new Vector2(0, 4), Quaternion.identity);
        x = 5; y = 10;
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > maxtimer)
        {
            Debug.Log("x : " + x + " y : " + y + "cnt : " + cnt);
            timer = 0;
            if (visit[x, y-1] == false)
            {
                y--;
                obj.transform.Translate(0, -0.4f, 0);
                Debug.Log("몇번 들어왔어?");

            } else
            {
                sync();
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && visit[x-1,y] == false)
        {
            Debug.Log("x : " + x + " y : " + y + "cnt : " + cnt);
            x--;
            obj.transform.Translate(-0.4f, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && visit[x+1,y] == false)
        {
            Debug.Log("x : " + x + " y : " + y + "cnt : " + cnt);
            x++;
            obj.transform.Translate(0.4f, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && visit[x,y-1] == false)
        {
            Debug.Log("x : " + x + " y : " + y + "cnt : " + cnt);
            y--;
            obj.transform.Translate(0, -0.4f, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            while(visit[x, y-1] == false)
            {
                cnt++;
                y--;
                
            }
            Debug.Log("스페이스바 찍혔다");
            Debug.Log("x : " + x + " y : " + y + "cnt : "+cnt);
            obj.transform.Translate(0, -0.4f * cnt,0);
            timer = 0;
            cnt = 0;
            sync();
            
        }
    }
}
