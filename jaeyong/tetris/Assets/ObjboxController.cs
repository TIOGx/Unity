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
    private GameObject background;
    private float topy = 4.7f;

    // -4.74~y~4.74 , -2.56~x~2.56, 한 y좌표에 들어갈 수 있는 타일 개수 11개
    // 한 칸에 차지하는 길이 ) 0.5
    void CreateTile(float x, float y)
    {
        GameObject tet = Instantiate(tile);
        tet.transform.parent = objbox.transform;
        tet.transform.localPosition = new Vector2(x, y);
    }
    void CreateTet()
    {
        objbox.transform.position = new Vector2(0, topy);
        int r = Random.Range(0, 4);
        if(r == 0)
        {
            CreateTile(0f, 0f);
            CreateTile(0.5f, 0f);
            CreateTile(-0.5f, 0f);
            CreateTile(-1f, 0f);
        }
        if(r == 1)
        {
            CreateTile(0f, 0f);
            CreateTile(0.5f, 0f);
            CreateTile(-0.5f, 0f);
            CreateTile(-0.5f, 0.5f);
        }
        if(r == 2)
        {
            CreateTile(0f, 0f);
            CreateTile(0.5f, 0f);
            CreateTile(-0.5f, 0f);
            CreateTile(0.5f, 0.5f);
        }
        if(r == 3)
        {
            CreateTile(0f, 0f);
            CreateTile(0.5f, 0f);
            CreateTile(0f, 0.5f);
            CreateTile(0.5f, 0.5f);
        }
        
    }

    bool check()
    {
        return true;
    }
    // Start is called before the first frame update
    void Start()
    {
        CreateTet();
    }

    // Update is called once per frame
    void Update()
    {
        if()
    }
}
