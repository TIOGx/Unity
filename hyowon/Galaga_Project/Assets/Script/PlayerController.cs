using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public float reload;
    public GameObject[] Bullet;
    public bool isDelay;
    public int powerlevel;
    void Start()
    {
        powerlevel = 1;
    }

    void Update()
    {
        Move(); // 움직임
        
        if(!isDelay){ // 코루틴을 통해 재장전 속도에 따른 총알 발사
            isDelay = true;
            Fire();
            StartCoroutine(CountAttackDelay());
        }
    }   

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
        Instantiate(Bullet[powerlevel], transform.position, Quaternion.identity);
    }
    IEnumerator CountAttackDelay(){
        yield return new WaitForSeconds(reload);
        isDelay = false;
}
}
