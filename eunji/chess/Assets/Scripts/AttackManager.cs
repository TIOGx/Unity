using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    public List<GameObject> MyPiece;
    public void Start(){
    }
    public void BattlePhase(){
        MyPiece = GameManager.instance.MyPiece;
        foreach (GameObject el in MyPiece){
            el.GetComponent<PieceController>().Attack();
        }
    }
}
