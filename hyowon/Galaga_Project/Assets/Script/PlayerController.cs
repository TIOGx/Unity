using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float Speed;
    public float reload;
    public int playerHP;
    public GameObject[] Bullet;
    public bool isDelay;
    public int powerlevel;
    public int Playerboom;
    public GameObject gameOverSet;


    void Start()
    {
        powerlevel = 0; // 초기 파워 설정
    }

    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.A)){ //파워업키 귀찮아서 만듬
            Powerup();
        }
        else if(Input.GetKeyDown(KeyCode.S)){ //폭탄 사용키 
            UseBoom();
            
        }
        Move(); // 움직임
        
        if(!isDelay){ // 코루틴을 통해 재장전 속도에 따른 총알 발사
            isDelay = true;
            Fire();
            StartCoroutine(CountAttackDelay());
        }
    }   
///////////////////////////////////////////////////////////////////////////////////////////


    void Move(){
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");
        Vector3 PlayerPosition = transform.position;
        
        PlayerPosition.x += Horizontal * Speed * Time.deltaTime;
        PlayerPosition.y += Vertical * Speed * Time.deltaTime;
        // 화면밖으로 플레이어가 나가는 경우 처리
        Vector3 pos = Camera.main.WorldToViewportPoint(PlayerPosition); // 각방향으로 화면 밖으로 나갈 경우
        if (pos.x < 0f) pos.x = 0f;
        if (pos.x > 1f) pos.x = 1f;
        if (pos.y < 0f) pos.y = 0f;
        if (pos.y > 1f) pos.y = 1f;
        PlayerPosition = Camera.main.ViewportToWorldPoint(pos); 
        transform.position = PlayerPosition; // Player 위치 조정
    }

    
    void Fire(){
        switch(powerlevel){ // 파워레벨에 따른 무기변경 및 장탄수 변경
            case 0:
                Instantiate(Bullet[powerlevel], transform.position + new Vector3 (0,0.7f,0), Quaternion.Euler(0,0,90)); // 총알이 전투기의 앞에서 나가도록 연출
                break;
            case 1:
                Instantiate(Bullet[powerlevel], transform.position + new Vector3 (-0.3f,0.7f,0), Quaternion.Euler(0,0,90)); // 총알이 전투기의 양옆에서 나가도록 연출
                Instantiate(Bullet[powerlevel], transform.position + new Vector3 (0.3f,0.7f,0), Quaternion.Euler(0,0,90)); 
                break;
            case 2:
                Instantiate(Bullet[powerlevel], transform.position + new Vector3 (0,0.7f,0), Quaternion.Euler(0,0,90)); // 총알이 전투기의 앞에서 3발 나가도록 연출
                Instantiate(Bullet[powerlevel], transform.position + new Vector3 (-0.3f,0.7f,0), Quaternion.Euler(0,0,90));
                Instantiate(Bullet[powerlevel], transform.position + new Vector3 (0.3f,0.7f,0), Quaternion.Euler(0,0,90)); 
                break;
            // case 3:
            //     OnDrawGizmos();
            //     break;
        }
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySound("Fire");
    }
    IEnumerator CountAttackDelay(){
        yield return new WaitForSeconds(reload);
        isDelay = false;
    }
    void Powerup(){
        powerlevel += 1;
    }
    public void Hpdown(){
        playerHP -= 1;
        if(playerHP <= 0){
            PlayerDie();
        }
    }
    void PlayerDie(){
        gameOverSet.SetActive(true);
        GameObject.Find("EnemySpawner").SetActive(false);
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Item"){
            // 아이템에 따른 효과 부여;
            Debug.Log("템 먹음");
            if(collision.gameObject.name == "Heart(Clone)"){
                Debug.Log("체력 먹음");
                if(playerHP<3){
                    playerHP ++;
                }
            }
            else if(collision.gameObject.name == "boom(Clone)"){
                Debug.Log("폭탄 먹음");
                Playerboom ++;
            }
            else if(collision.gameObject.name == "power(Clone)"){
                Debug.Log("파워 먹음");
                if(powerlevel <2){
                    Powerup();
                }
            }
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "Enemy"){// 플레이어 체력 감소
            Hpdown();
            // Destroy(gameObject);
        }
    }
    void UseBoom(){
        if(Playerboom > 0){
            Playerboom -- ;
            int cnt = 0;
            cnt = GameObject.Find("EnemySpawner").GetComponent<EnemyCreator>().NowEnemies.Count;
            for(int i = 0 ; i < cnt ; i++){
                if(GameObject.Find("EnemySpawner").GetComponent<EnemyCreator>().NowEnemies[i] != null){
                    GameObject.Find("EnemySpawner").GetComponent<EnemyCreator>().NowEnemies[i].GetComponent<EnemyController>().Damaged(100f);
                }
            }
            Debug.Log("폭탄사용");

        }
    }
//     void OnDrawGizmos() {
 
//         float maxDistance = 15f;
//         RaycastHit hit;
//         // Physics.Raycast (레이저를 발사할 위치, 발사 방향, 충돌 결과, 최대 거리)
//         bool isHit = Physics.Raycast(transform.position, transform.forward, out hit, maxDistance);
 
//         Gizmos.color = Color.red;
//         if (isHit) {
//             Gizmos.DrawRay(transform.position, transform.forward * hit.distance,Color.red,0.3f);
//         } 
//         else {
//             Gizmos.DrawRay(transform.position, transform.forward * maxDistance,Color.red,0.3f);
//         }
//     }

}
