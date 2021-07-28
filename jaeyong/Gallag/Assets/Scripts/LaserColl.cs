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
        if(collision.gameObject.tag != "Player") // player�� �������� �浹 ����
        {
            if (this.gameObject.tag == "Bestlaser") // ���� ���� ������ �ǵ��� ���� ������ 2��
            {
                if (collision.gameObject.tag != "Bestlaser") // �� ���������� �ε����� ������ ���� �ʰ�.
                {
                    Instantiate(explosion, transform.position, Quaternion.identity);
                    Destroy(collision.gameObject);
                }
            }


            if (collision.gameObject.tag == "Sky") // �ϴÿ� �ε����� ����
            {
                Destroy(this.gameObject);
            }

            if (collision.gameObject.tag == "Enemy") // ���� �ε����� ����. ���� �߰�
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                GameManager.Instance.addScore(10);
                Destroy(this.gameObject);
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.tag == "EnemyLaser") // ���� �ε����� ����. ���� �߰�
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.tag == "Boss") // ������ �ε����� ī��Ʈ�÷��� 5���̻󶧸��� ����.. hp�� �����ߵǴµ� �ӽ������� cnt
            {
                GetComponent<BossController>().HitBossHP();
                Instantiate(explosion, transform.position, Quaternion.identity);
                // GameManager.Instance.addScore(50);
                Destroy(this.gameObject);
                hit = GetComponent<BossController>().GetBossHP();
                Debug.Log("������ �¾Ҿ��+"+hit+"��ŭ");

                if(hit >= 5)
                {
                    Debug.Log("������ �׾���ؿ�");
                    Destroy(collision.gameObject);
                }
                
            }
        }
    }
}
