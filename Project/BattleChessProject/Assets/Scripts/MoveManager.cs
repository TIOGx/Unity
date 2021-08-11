using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveManager : MonoBehaviour
{

    public static MoveManager instance;
    public int originx, originz;
    public bool moveflag = false;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit = new RaycastHit();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.Log("클릭");
            if(Physics.Raycast(ray, out hit))
            {
                int x = (int)hit.transform.position.x;
                int z = (int)hit.transform.position.z;

                if(hit.transform.tag == "BlackTeam")
                {
                    if(hit.transform.gameObject.GetComponent<PieceController>().Movable == true && moveflag == false)
                    {
                        Debug.Log("x : " + x + " z : " + z);
                        originx = x;
                        originz = z;
                        for (int i = 0; i < 8; i++)
                        {
                            GameManager.instance.HighlightTile(GameManager.instance.Tiles[i, z]);
                            GameManager.instance.HighlightTile(GameManager.instance.Tiles[x, i]);
                        }
                        moveflag = true;
                    } else
                    {
                        if(moveflag == true)
                        {
                            Debug.Log("눌렀던거 취소할게요");
                            GameManager.instance.InitializeTile();
                            moveflag = false;
                        } else
                        {
                            Debug.Log("아직 이동할 수 없어요");
                        }
                    }
                }
                else if(hit.transform.tag == "Map" && moveflag == true)
                {
                    moveflag = false;
                    GameManager.instance.Board[originx, originz].GetComponent<PieceController>().Move(x, z, originx, originz);
                    Debug.Log("이미 다른 말이 점거하고 있거나, 이동할 수 없는 칸이에요");
                }
            }
        }
    }

}
