using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   

    public static GameManager instance;
    public List<GameObject> MyPiece; // 내가 소환한 말들
    public GameObject EnemyPiece;
    public GameObject[,] Board;
    public int ChooseTileCount = 0;

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
    // 선택된 타일의 개수 확인
    public bool CheckTileCount()
    {
        if (ChooseTileCount == 0) return true;
        else return false;
    }

    // 선택된 타일의 개수 조정
    public void TileCount(int cnt) 
    {
        ChooseTileCount += cnt;
    }
    public void SpawnEnemy(){
        BuildManager.instance.BuildPiece(EnemyPiece);
    }

}
