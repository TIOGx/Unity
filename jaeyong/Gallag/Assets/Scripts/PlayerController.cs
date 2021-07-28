using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rigid2D;
    float Force = 6f;
    [SerializeField]
    private ParticleSystem exp;
    [SerializeField]
    private GameObject player;
    private float maxtimer = 0.1f;
    private float timer = 0f;
    private int level = 1;
    // Start is called before the first frame update
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        level = 1;
        StartCoroutine(Forceup());
    }
    void levelup()
    {
        level++;
    }
    void ScreenCheck()
    {
        Vector3 WorlPos = Camera.main.WorldToViewportPoint(this.transform.position);
        if (WorlPos.x < 0.05f)
        {
            WorlPos.x = 0.05f;
        }
        if (WorlPos.x > 0.95f)
        {
            WorlPos.x = 0.95f;
        }
        if(WorlPos.y < 0.05f)
        {
            WorlPos.y = 0.05f;
        }
        if(WorlPos.y > 0.95f)
        {
            WorlPos.y = 0.95f;
        }
        this.transform.position = Camera.main.ViewportToWorldPoint(WorlPos);
    }
    void Shootlaser()
    {
        GameObject.FindWithTag("Generator").GetComponent<LaserController>().shoot(GameManager.Instance.getLevel(), player);
        Debug.Log("ÃÑ¾Ë½õ´Ï´Ù");
    }
    IEnumerator Forceup()
    {
        Force += 0.1f;
        yield return new WaitForSeconds(0.5f);
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        float x = Input.GetAxisRaw("Horizontal");   //ÁÂ¿ì ÀÌµ¿
        float y = Input.GetAxisRaw("Vertical");     //»óÇÏ ÀÌµ¿
        rigid2D.velocity = new Vector3(x, y, 0) * Force;
        ScreenCheck();
        if (Input.GetKey(KeyCode.Space) && timer > maxtimer)
        {
            timer = 0;
            Shootlaser();
        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Boss" || collision.gameObject.tag == "EnemyLaser")
        {
            Instantiate(exp, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            GameManager.Instance.isGameOver();
        }
    }
}
