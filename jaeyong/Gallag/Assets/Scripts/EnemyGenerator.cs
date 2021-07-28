using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemy;
    [SerializeField]
    private GameObject EnemySpawner;
    private int cnt = 0;
    private float timer = 0f;
    // private float maxshoottimer = 10f;
    // private float shoottimer = 0f;
    private int enemylevel = 2;
    private float randomtimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rand();
    }
    void rand()
    {
        randomtimer = Random.Range(0.8f, 2f);
    }
    public void enemyLevelUp()
    {
        if(enemylevel <= 1) enemylevel++;
        
    }
    IEnumerator CreateBoss()
    {
        GameObject go = Instantiate(enemy[enemylevel], EnemySpawner.transform) as GameObject;
        go.transform.localPosition = new Vector3(0, 0, 0);
        go.GetComponent<Rigidbody2D>().gravityScale = 0.1f;
        yield return new WaitForSeconds(10f);
        yield break;
    }
    void CreateEnemy()
    {
        
        
        if(enemylevel == 0)
        {
            GameObject go = Instantiate(enemy[enemylevel], EnemySpawner.transform) as GameObject;
            go.transform.localPosition = new Vector3(Random.Range(-2.3f, 2.3f), 0, 0);
            go.GetComponent<Rigidbody2D>().gravityScale = Random.Range(0.5f, 1.0f);
        } if(enemylevel == 1)
        {
            GameObject go = Instantiate(enemy[enemylevel], EnemySpawner.transform) as GameObject;
            go.transform.localPosition = new Vector3(Random.Range(-2.3f, 2.3f), 0, 0);
            go.GetComponent<Rigidbody2D>().gravityScale = Random.Range(1.0f, 1.5f);
        } if(enemylevel == 2)
        {
            StartCoroutine(CreateBoss());
            timer = -2000f;
        }
        
    }
    /* void Shootlaser()
    {
        GameObject.FindWithTag("Generator").GetComponent<LaserController>().shoot(1, enemy[enemylevel]);
    }
    */
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        // shoottimer += Time.deltaTime;
        if(timer > randomtimer)
        {
            if(enemylevel <= 1)
            {
                timer = 0;
                rand();
                int r = Random.Range(1, 3);
                while (r-- >= 0)
                {
                    CreateEnemy();
                    cnt++;
                    if (cnt >= 15)
                    {
                        break;
                    }
                }
                if (cnt > 15)
                {
                    cnt = 0;
                    enemyLevelUp();
                    timer = -2f;
                }
            }
            if(enemylevel >= 2)
            {
                CreateEnemy();
            }
        }
        /* if(shoottimer > maxshoottimer)
        {
            shoottimer = 0;
            Shootlaser();
        } */
    }
    
}
