using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public GameObject SelectTile;
    public GameObject BuieldedPiece;

    [SerializeField]
    public GameObject[] PiecePrefab = new GameObject[5];

    [SerializeField]
    public GameObject ChoosePieceCanvas;
    public GameObject selectposCanvas;


    public void Start(){
        instance = this;
        ChoosePieceCanvas.SetActive(false);
        selectposCanvas.SetActive(false);
    }

    public void BuildPiece(int i)
    {
        Vector3 selectpos = SelectTile.transform.position;
        BuieldedPiece = Instantiate(PiecePrefab[i], selectpos, Quaternion.identity);

        GameManager.instance.Board[(int)selectpos.x, (int)selectpos.z] = BuieldedPiece;
        ChoosePieceCanvas.SetActive(false);

    }

    public void SelectPiece()
    {
        if (SelectTile == null)
        {
            Debug.Log("위치 선택 안함");
            selectposCanvas.SetActive(true);

        }
        else
        {
            selectposCanvas.SetActive(false);
            ChoosePieceCanvas.SetActive(true);
        }

      

    }

}
