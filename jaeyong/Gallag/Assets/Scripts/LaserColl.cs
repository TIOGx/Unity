using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserColl : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem explosion;
    private int hit = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "Player") // player와 레이저의 충돌 방지
        {
            if (this.gameObject.tag == "Bestlaser") // 가장 힘쎈 레이저 의도는 원래 데미지 2배
            {
                if (collision.gameObject.tag != "Bestlaser") // 는 레이저끼리 부딪혀도 삭제가 되지 않게.
                {
                    Instantiate(explosion, transform.position, Quaternion.identity);
                    Destroy(collision.gameObject);
                }
            }


            if (collision.gameObject.tag == "Sky") // 하늘에 부딪히면 삭제
            {
                Destroy(this.gameObject);
            }

            if (collision.gameObject.tag == "Enemy") // 적에 부딪히면 삭제. 점수 추가
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                GameManager.Instance.addScore(10);
                Destroy(this.gameObject);
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.tag == "EnemyLaser") // 적에 부딪히면 삭제. 점수 추가
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.tag == "Boss") // 보스에 부딪히면 카운트올려서 5번이상때리면 삭제.. hp를 만들어야되는데 임시적으로 cnt
            {
                GetComponent<BossController>().HitBossHP();
                Instantiate(explosion, transform.position, Quaternion.identity);
                // GameManager.Instance.addScore(50);
                Destroy(this.gameObject);
                hit = GetComponent<BossController>().GetBossHP();
                Debug.Log("보스가 맞았어요+"+hit+"만큼");

                if(hit >= 5)
                {
                    Debug.Log("보스가 죽어야해요");
                    Destroy(collision.gameObject);
                }
                
            }
        }
    }
}
