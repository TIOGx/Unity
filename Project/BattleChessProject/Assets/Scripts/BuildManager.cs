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

    public void BuildPiece(GameObject Piece) 
    {
        Vector3 selectpos = SelectTile.transform.position;
        BuildedPiece = Instantiate(Piece, selectpos, Piece.transform.rotation);

        GameManager.instance.Board[(int)selectpos.x, (int)selectpos.z] = BuildedPiece;

        // GameDirector.instance.OpenBuildPieceUI();
        //Debug.Log(MovePieceCanvas.transform.parent);
        ChoosePieceCanvas.SetActive(false);

        GameManager.instance.TileCount(-1);
        Tile tile = SelectTile.GetComponent<Tile>();
        Color Idle = tile.GetIdleColor();
        tile.SetIdleColor(Idle);
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
