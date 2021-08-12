using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   

    public static GameManager instance;
    public List<GameObject> MyPiece; // 내가 소환한 말들
    public GameObject EnemyPiece;
    public GameObject[,] Board;
    public GameObject[,] Tiles;

    public void Awake(){
        instance = this;
        MyPiece = new List<GameObject>(); 
        Board = new GameObject[8, 8];
        Tiles = new GameObject[8, 8];
    }
    public void InitializeTile()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                GameObject GObject = Tiles[i, j];
                for (int k = 0; k < 4; k++)
                {
                    GObject.transform.GetChild(k).gameObject.SetActive(false);
                }
            }
        }
        BuildManager.instance.InitializeSelectTile();
    }
    public void HighlightTile(GameObject GObject) // 갈 수 있는 타일 highlight
    {
        GObject.GetComponent<Tile>().Movable = true;
        for(int i = 0; i < GObject.transform.childCount; i++)
        {
            GObject.transform.GetChild(i).gameObject.SetActive(true);
        }
        GObject.GetComponent<Animator>().Play("TileAnim");
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
            el.GetComponent<PieceController>().Movable = true;
        }
    }
    public void SpawnEnemy(){
        BuildManager.instance.BuildPiece(EnemyPiece);
    }

}
