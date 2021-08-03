using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Color IdleColor;
    public Color SelectColor;
    public Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
        IdleColor = rend.material.color;
        SelectColor = Color.green;
    }

    private void OnMouseUp() {
        rend.material.color = SelectColor;
    }
}
