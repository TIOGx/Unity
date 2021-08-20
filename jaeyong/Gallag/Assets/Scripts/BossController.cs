using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private float speed = 0.5f;
    [SerializeField]
    private Rigidbody2D laser;
    private float timer = 0;
    private float maxtimer = 0.5f;
    private int hit = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void bossshootlaser()
    {
        Rigidbody2D PrefabInstance = Instantiate(laser, this.transform);
        //Debug.Log("시발련아 좌표내나" + PrefabInstance.transform.position.x + " " + PrefabInstance.transform.position.y + " ");
        PrefabInstance.velocity = new Vector3(Random.Range(-5.5f,5.5f), Random.Range(-0.5f,-1f), 0) * speed;
        PrefabInstance = Instantiate(laser, this.transform);
        PrefabInstance.velocity = new Vector3(Random.Range(-5.5f, 5.5f), Random.Range(-0.5f, -1f), 0) * speed;
    }
    public void HitBossHP()
    {
        hit++;
    }
    public int GetBossHP()
    {
        return (5 - hit);
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > maxtimer)
        {
            timer = 0;
            bossshootlaser();
        }
    }
}
