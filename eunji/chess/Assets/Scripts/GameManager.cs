using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
    public static GameManager instance;
    public List<GameObject> MyPiece;

    public GameObject[,] Board;
    public void Start(){
        instance = this;
        MyPiece = new List<GameObject>(); 
        Board = new GameObject[8,8];
    }


}
