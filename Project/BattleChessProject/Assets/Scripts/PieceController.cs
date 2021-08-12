using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PieceType{
    Bishop,
    King,
    Knight,
    Pawn,
    Queen,
    Rook,
    None
}
public class PieceController : MonoBehaviour
{

    private PieceType Piecetype;
    private string TypeName;
    public float Hp;
    public float nowHp;
    public float OffensePower;
    public int Dir;
    public bool Attackable;
    public bool Movable;
    public int[] dx = new int[]{0,1,0,-1,1,1,-1,-1};
    public int[] dy = new int[]{1,0,-1,0,1,-1,1,-1};
    public GameObject hudDamageText;
    public Transform Hudpos;
    public GameObject HealthBar;
    void Start(){
        TypeName = this.gameObject.name.Substring(0, 4);
        if(this.tag == "BlackTeam"){
            GameManager.instance.MyPiece.Add(this.gameObject);
            if (TypeName == "Bish")
                Piecetype = PieceType.Bishop;
            else if (TypeName == "King")
                Piecetype = PieceType.King;
            else if (TypeName == "Knig")
                Piecetype = PieceType.Knight; 
            else if (TypeName == "Pawn")
                Piecetype = PieceType.Pawn; 
            else if (TypeName == "Quee")
                Piecetype = PieceType.Queen;
            else if(TypeName == "Rook")
                Piecetype = PieceType.Rook;
        
        }
        Dir = (int) (gameObject.transform.rotation.z / 90) % 4; // 0,1,2,3
        Attackable = false;
        Movable = false;
        nowHp = Hp;
    }
    public PieceType GetPiecetype()
    {
        return Piecetype;
    }
    public void Damaged(float damage){
        // GameObject hudText = Instantiate(hudDamageText); 
        // hudText.transform.position = Hudpos.position;
        // hudText.GetComponent<DamageText>().damage = damage;
        nowHp -= damage;
        // HealthBar.GetComponent<Image>().fillAmount = nowHp/Hp;
        Die();
    }
    public void Attack(){
        if(Attackable){
            if(GameManager.instance.Board[(int)transform.position.x + dx[Dir],(int)transform.position.z + dy[Dir]] != null  && GameManager.instance.Board[(int)transform.position.x + dx[Dir],(int)transform.position.z + dy[Dir]].tag != this.tag){
                Debug.Log("공격!");
                GameManager.instance.Board[(int)transform.position.x + dx[Dir],(int)transform.position.z + dy[Dir]].GetComponent<PieceController>().Damaged(OffensePower);
                Attackable = false;
            }
            
        }
    }
    public void Move(int x, int z, int originx, int originz)
    {
        if (Movable)
        {
            GameManager.instance.Board[originx, originz].transform.position = new Vector3(x, 0, z);
            GameManager.instance.Board[x, z] = GameManager.instance.Board[originx, originz];
            GameManager.instance.Board[originx, originz] = null;
            GameManager.instance.InitializeTile();
            Movable = false;
        } else
        {
            Debug.Log("Move 불가능합니다");
        }
    }

    public void Die(){
        if(nowHp <= 0){
            Destroy(gameObject);
        }
    }
}
