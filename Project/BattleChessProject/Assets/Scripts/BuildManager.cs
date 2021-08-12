using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public GameObject SelectTile;
    public GameObject BuildedPiece;

    [SerializeField]
    public GameObject[] PiecePrefab = new GameObject[5];

    [SerializeField]
    public GameObject ChoosePieceCanvas;
    public GameObject SelectPosCanvas;
    public GameObject MovePieceCanvas;

    IEnumerator SetActiveFalse(GameObject gameObject,float WaitSeconds)
    {
        yield return new WaitForSeconds(WaitSeconds);
        gameObject.SetActive(false);
    }

    public void Start(){
        instance = this;
        // ChoosePieceCanvas.SetActive(false);
        // SelectPosCanvas.SetActive(false);
        // MovePieceCanvas.SetActive(false);
    }
    public void InitializeSelectTile()
    {
        SelectTile = null;
    }
    public void BuildPiece(GameObject Piece) 
    {
        Vector3 selectpos = SelectTile.transform.position;
        if(GameManager.instance.Board[(int)selectpos.x, (int)selectpos.z] == null)
        {
            BuildedPiece = Instantiate(Piece, selectpos, Piece.transform.rotation);
        }
        else
        {
            Debug.Log("이미 있는 자리에 또 만드려고 했어요");
            ChoosePieceCanvas.SetActive(false);
            return;
        }
        GameManager.instance.Board[(int)selectpos.x, (int)selectpos.z] = BuildedPiece;
        GameManager.instance.InitializeTile();
        // GameDirector.instance.OpenBuildPieceUI();
        //Debug.Log(MovePieceCanvas.transform.parent);
        ChoosePieceCanvas.SetActive(false);
    }

    public void SelectPiece()
    {
        if (SelectTile == null)
        {
            Debug.Log("위치 선택 안함");
            SelectPosCanvas.SetActive(true);
            StartCoroutine(SetActiveFalse(SelectPosCanvas,1.5f));
        }
        else
        {
            SelectPosCanvas.SetActive(false);
            ChoosePieceCanvas.SetActive(true);
        }

    }
    public void MovePiece()
    {
       
    }
}
