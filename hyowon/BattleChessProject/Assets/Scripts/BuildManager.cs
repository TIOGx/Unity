using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public GameObject SelectTile;
    public GameObject Piece;
    public GameObject BuieldedPiece;

    public void Start(){
        instance = this;
    }
    public void BuildPiece(GameObject Piece){
        Vector3 selectpos = SelectTile.transform.position;
        BuieldedPiece = Instantiate(Piece, selectpos, Quaternion.identity);
        GameManager.instance.Board[(int)selectpos.x, (int)selectpos.z] = BuieldedPiece;
        // Debug.Log(GameManager.instance.Board[(int)selectpos.x, (int)selectpos.z]);
    }
}
