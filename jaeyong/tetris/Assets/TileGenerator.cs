using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    private int r = -1;
    [SerializeField]
    private GameObject objbox;
    [SerializeField]
    private GameObject tile;
    // Start is called before the first frame update
    void Start()
    {
        CreateTet();

    }
    void CreateTile(float x, float y)
    {
        GameObject tet = Instantiate(tile);
        tet.transform.parent = objbox.transform;
        tet.transform.localPosition = new Vector2(x, y);
    }
    public void CreateTet()
    {
        objbox.transform.position = new Vector2(4, 14);
        int r = Random.Range(0, 4);
        if (r == 0) // 90, 0
        {
            CreateTile(0f, 0f);
            CreateTile(1f, 0f);
            CreateTile(-1f, 0f);
            CreateTile(-2f, 0f);
        }
        if (r == 1)
        {
            CreateTile(0f, 0f);
            CreateTile(1f, 0f);
            CreateTile(-1f, 0f);
            CreateTile(-1f, 1f);
        }
        if (r == 2)
        {
            CreateTile(0f, 0f);
            CreateTile(1f, 0f);
            CreateTile(-1f, 0f);
            CreateTile(1f, 1f);
        }
        if (r == 3)
        {
            CreateTile(0f, 0f);
            CreateTile(1f, 0f);
            CreateTile(0f, 1f);
            CreateTile(1f, 1f);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
