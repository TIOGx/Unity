using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public List<GameObject> MyPiece;
    public void NextTurn(){
        Debug.Log("턴종료 다음턴 시작");
        MyPiece = GameManager.instance.MyPiece;
        foreach (GameObject el in MyPiece){
            el.GetComponent<PieceController>().Attackable = true;
        }
    }
}
