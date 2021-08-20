using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisCreator : MonoBehaviour
{
    public GameObject [] obj;
    // public GameObject GameOver;
    public void CreatBlock()
    {
        Instantiate(obj[Random.Range(0,obj.Length)], transform.position, Quaternion.identity);
    }
    // Start is called before the first frame update
    void Start()
    {
        CreatBlock();
        // GameOver = GameObject.Find("GameOver");
        // GameOver.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

}
