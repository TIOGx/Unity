using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
    public static GameManager instance;
    public List<GameObject> MyPiece;
    public GameObject EnemyPiece;
    public GameObject[,] Board;

    public void Start(){
        instance = this;
        MyPiece = new List<GameObject>(); 
        Board = new GameObject[8,8];

    }
    // 전투 페이즈 담당 함수    
    public void BattlePhase(){
        MyPiece = GameManager.instance.MyPiece;
        foreach (GameObject el in MyPiece){
            el.GetComponent<PieceController>().Attack();
        }
    }

    // 턴 종료 페이즈 담당 함수 
    public void NextTurn(){
        Debug.Log("턴종료 다음턴 시작");
        MyPiece = GameManager.instance.MyPiece;
        foreach (GameObject el in MyPiece){
            el.GetComponent<PieceController>().Attackable = true;
        }
    }

    public void SpawnEnemy(){
        BuildManager.instance.BuildPiece(EnemyPiece);
    }

}
