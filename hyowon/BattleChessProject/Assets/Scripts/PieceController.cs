using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceController : MonoBehaviour
{

    public float Hp;
    public float OffensePower;
    public float Dir;
    public bool Attackable;
    void Start(){
        GameManager.instance.MyPiece.Add(this.gameObject);
        Dir = gameObject.transform.rotation.z;
        Attackable = false;
    }

    public void Hit(GameObject target, float dmg){
        target.GetComponent<PieceController>().Hp -= dmg;
    }
    public void Attack(){
        if(Attackable){
            if(GameManager.instance.Board[(int)transform.position.x,(int)transform.position.z + 1] != null){
                Debug.Log("공격!");
                Hit(GameManager.instance.Board[(int)transform.position.x,(int)transform.position.z + 1], OffensePower);
                Attackable = false;
            }
            
        }
    }
    public void Update(){
        Die();
    }
    public void Die(){
        if(Hp <= 0 ){
            Destroy(gameObject);
        }
    }
}
