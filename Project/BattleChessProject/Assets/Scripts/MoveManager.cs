using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveManager : MonoBehaviour
{
    public int[] dx = { 0, 1, 0, -1, 1, 1, -1, -1 };
    public int[] dz = { 1, 0, -1, 0, 1, -1, 1, -1 };
    public int[] knightx = { -2, -1, 1, 2, -2, -1, 1, 2 };
    public int[] knightz = { -1, -2, -2, -1, 1, 2, 2, 1 };
    public static MoveManager instance;
    public int originx, originz;
    public bool moveflag = false;
    public void MovablePieceHighlight(GameObject GObject)
    {
        Debug.Log("type : " + GObject.GetComponent<PieceController>().GetPiecetype());
        int x = (int)GObject.transform.position.x;
        int z = (int)GObject.transform.position.z;
        switch (GObject.GetComponent<PieceController>().GetPiecetype())
        {
            case PieceType.Bishop:
                Debug.Log("����� ���õƾ��.");
                for(int i = 4; i < 8; i++)
                {
                    for(int j=1; j<8 ;j++)
                    {
                        int nx = x + j * dx[i]; // 4 
                        int nz = z + j * dz[i]; // 1
                        if (nx < 0 || 8 <= nx || nz < 0 || 8 <= nz)
                            break;
                        else if (GameManager.instance.Board[nx, nz] == null)
                        {
                            GameManager.instance.Tiles[nx, nz].GetComponent<Tile>().Movable = true;
                            GameManager.instance.HighlightTile(GameManager.instance.Tiles[nx, nz]);
                        } else
                        {
                            break;
                        }
                    }
                }
                break;
            case PieceType.King:
                Debug.Log("ŷ�� ���õƾ��.");
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 1; j < 2; j++)
                    {
                        int nx = x + j * dx[i]; // 4 
                        int nz = z + j * dz[i]; // 1
                        if (nx < 0 || 8 <= nx || nz < 0 || 8 <= nz)
                            break;
                        else if (GameManager.instance.Board[nx, nz] == null)
                        {
                            GameManager.instance.Tiles[nx, nz].GetComponent<Tile>().Movable = true;
                            GameManager.instance.HighlightTile(GameManager.instance.Tiles[nx, nz]);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                break;
            case PieceType.Knight:
                Debug.Log("����Ʈ�� ���õƾ��.");
                for (int i = 0; i < 8; i++)
                {
                    int nx = x + knightx[i]; // 4 
                    int nz = z + knightz[i]; // 1
                    if (nx < 0 || 8 <= nx || nz < 0 || 8 <= nz)
                        continue;
                    else if (GameManager.instance.Board[nx, nz] == null)
                    {
                        GameManager.instance.Tiles[nx, nz].GetComponent<Tile>().Movable = true;
                        GameManager.instance.HighlightTile(GameManager.instance.Tiles[nx, nz]);
                    }
                }
                break;
            case PieceType.Pawn:

                if (GameManager.instance.Board[x, z + 1] == null)
                {
                    GameManager.instance.Tiles[x, z+1].GetComponent<Tile>().Movable = true;
                    GameManager.instance.HighlightTile(GameManager.instance.Tiles[x, z+1]);
                }
                    
                break;
            case PieceType.Queen:
                Debug.Log("���� ���õƾ��.");
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 1; j < 8; j++)
                    {
                        int nx = x + j * dx[i]; // 4 
                        int nz = z + j * dz[i]; // 1
                        if (nx < 0 || 8 <= nx || nz < 0 || 8 <= nz)
                            break;
                        else if (GameManager.instance.Board[nx, nz] == null)
                        {
                            GameManager.instance.Tiles[nx, nz].GetComponent<Tile>().Movable = true;
                            GameManager.instance.HighlightTile(GameManager.instance.Tiles[nx, nz]);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                break;
            case PieceType.Rook:
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 1; j < 8; j++)
                    {
                        int nx = x + j * dx[i]; // 4 
                        int nz = z + j * dz[i]; // 1
                        if (nx < 0 || 8 <= nx || nz < 0 || 8 <= nz)
                            break;
                        else if (GameManager.instance.Board[nx, nz] == null)
                        {
                            GameManager.instance.Tiles[nx, nz].GetComponent<Tile>().Movable = true;
                            GameManager.instance.HighlightTile(GameManager.instance.Tiles[nx, nz]);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                break;

            case PieceType.None:
                Debug.Log("�⹰�� Ÿ���� ���� �����");
                break;
        }
        
    }
    private void Update() // Enable�� ���ؼ��� �����...
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit = new RaycastHit();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.Log("Ŭ��");
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
                        GameManager.instance.InitializeTile();
                        MovablePieceHighlight(hit.transform.gameObject);
                        moveflag = true;
                    } else
                    {
                        if(moveflag == true)
                        {
                            Debug.Log("�������� ����ҰԿ�");
                            GameManager.instance.InitializeTile();
                            moveflag = false;
                        } else
                        {
                            Debug.Log("���� �̵��� �� �����");
                        }
                    }
                }
                else if(hit.transform.tag == "Map" && moveflag == true)
                {
                    moveflag = false;
                    GameManager.instance.Board[originx, originz].GetComponent<PieceController>().Move(x, z, originx, originz);
                }
            }
        }
    }

}
