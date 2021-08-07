using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceController : MonoBehaviour
{

    public float Hp;
    public float OffensePower;
    public int Dir;
    public bool Attackable;
    private int[] dx = new int[]{0,1,0,-1};
    private int[] dy = new int[]{1,0,-1,0};
    void Start(){
        if(this.tag == "BlackTeam"){
            GameManager.instance.MyPiece.Add(this.gameObject);
        }
        Dir = (int) (gameObject.transform.rotation.z / 90) % 4;
        Attackable = false;
        
    }
    public void Update(){
        Die();
    }

    public void Hit(GameObject target, float dmg){
        target.GetComponent<PieceController>().Hp -= dmg;
    }
    public void Attack(){
        if(Attackable){
            if(GameManager.instance.Board[(int)transform.position.x + dx[Dir],(int)transform.position.z + dy[Dir]] != null  && GameManager.instance.Board[(int)transform.position.x + dx[Dir],(int)transform.position.z + dy[Dir]].tag != this.tag){
                Debug.Log("공격!");
                Hit(GameManager.instance.Board[(int)transform.position.x + dx[Dir],(int)transform.position.z + dy[Dir]], OffensePower);
                Attackable = false;
            }
            
        }
    }

    public void Die(){
        if(Hp <= 0 ){
            Destroy(gameObject);
        }
    }
}
