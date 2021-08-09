using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private Color IdleColor;
    private Color SelectColor;
    private Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
        IdleColor = rend.material.color;
        SelectColor = Color.green;
    }
    public Color GetIdleColor()
    {
        return IdleColor;
    }
    public void SetIdleColor(Color SetColor)
    {
        rend.material.color = SetColor;
    }
    private void OnMouseUp()
    {
        if (BuildManager.instance.SelectTile == this.gameObject)
        {
            GameManager.instance.TileCount(-1);
            rend.material.color = IdleColor;
            BuildManager.instance.SelectTile = null;
        }

        else if (this.gameObject.transform.position.z <= 1 && GameManager.instance.CheckTileCount())
        {
            GameManager.instance.TileCount(1);
            rend.material.color = SelectColor;
            BuildManager.instance.SelectTile = this.gameObject;
        }
        else
        {
            Debug.Log("check tile count!");
        }
    }
}