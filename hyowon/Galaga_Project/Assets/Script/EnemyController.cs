using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{   
    public float reload;
    public GameObject EnemyBullet;
    public float Speed;
    public float hp;
    private float dropProb;
    public bool isDelay;
    public GameObject[] HaveItem;
    Transform playerPos; 
    Vector3 dir;
    void Start()
    {

    }

    void Update()
    {
        MoveDown();
        Die();
        if(!isDelay){ // 코루틴을 통해 재장전 속도에 따른 총알 발사
            isDelay = true;
            Fire();
            StartCoroutine(CountAttackDelay());
        }
    }



///////////////////////////////////////////////////////////////////////////////////////////
    void MoveDown(){
        Vector3 EnemyPosition = transform.position;
        EnemyPosition += new Vector3(0,-1f,0) * Speed * Time.deltaTime;  
        transform.position = EnemyPosition; // Enemy 위치 조정
    }

    
    void Die(){
        if(hp <= 0){
            GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySound("Die");
            DropItem(); //죽을때 아이템 드롭
            GameObject.Find("Score").GetComponent<ScoreBoard>().Score += 1;
            Destroy(gameObject);
        }
    }
    void Fire(){
        playerPos = GameObject.Find("Player_1").GetComponent<Transform>();
        dir = (playerPos.position - transform.position).normalized; // 총알 생성시 플레이어와 적 사이의 벡터 값 구하기 (방향)
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Instantiate(EnemyBullet, transform.position + new Vector3 (0,-0.7f,0), Quaternion.AngleAxis(angle,Vector3.forward)); // 플레이어를 바라보는 방향
    }
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "PlayerBullet"){
            GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySound("Hit"); // 소리 재생 및 데미지
            Damaged(collision.gameObject.GetComponent<BulletController>().bulletdmg);// 데미지 계산
        }
        else if (collision.gameObject.tag == "Border"){
                Destroy(gameObject);
        }
    }

    public void Damaged(float dmg){
        hp -= dmg;
    }

    void DropItem(){
        dropProb = Random.Range(0f,1f);
        if(dropProb < 0.4){
            return;
        }
        else if(dropProb<0.6){ // 20프로 확률로 폭탄 아이템 드랍.
            Instantiate(HaveItem[0], transform.position ,Quaternion.Euler(0,0,0));
            return;
        }
        else if(dropProb<0.8){ // 20프로 확률로 파워업 아이템 드랍.
            Instantiate(HaveItem[1], transform.position ,Quaternion.Euler(0,0,0));
            return;
        }
        else if(dropProb<0.9){ // 10프로 확률로 HP 회복 아이템 드랍.
            Instantiate(HaveItem[2], transform.position ,Quaternion.Euler(0,0,0));
            return;
        }
        else{ // 10프로확률로 펫 획득 아이템 드랍.
            return;
        }
    }
    IEnumerator CountAttackDelay(){
        yield return new WaitForSeconds(reload);
        isDelay = false;
    }   
}
