using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private Color IdleColor;
    private Color SelectColor;
    private Renderer rend;
    public bool Movable; // Tile Movable은 이동할 수 있는 칸인지 체크하기 위하여
    private void Start()
    {
        rend = GetComponent<Renderer>();
        IdleColor = rend.material.color;
        SelectColor = Color.green;
        Movable = false;
        GameManager.instance.Tiles[(int)transform.position.x, (int)transform.position.z] = this.gameObject;
    }
    public Color GetIdleColor()
    {
        return IdleColor;
    }
    private void OnMouseUp()
    {
        if (this.gameObject.transform.position.z <= 1)
        {
            if (GameManager.instance.Board[(int)transform.position.x, (int)transform.position.z] == null && BuildManager.instance.SelectTile != this.gameObject)
            {
                GameManager.instance.InitializeTile();
                BuildManager.instance.SelectTile = this.gameObject;
                GameManager.instance.HighlightTile(this.gameObject);
            } else
            {
                GameManager.instance.InitializeTile();
                BuildManager.instance.SelectTile = null;
            }
        }
    }
}