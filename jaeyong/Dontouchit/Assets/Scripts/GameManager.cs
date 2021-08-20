using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }
    [SerializeField]
    GameObject[] poop = new GameObject[5];
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreatePoopRoutine());
    }
    public void Score()
    {
        score++;
        Debug.Log(score);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator CreatePoopRoutine()
    {
        while (true)
        {
            CreatePoop();
            yield return new WaitForSeconds(1);
        }
        
    }
    private void CreatePoop()
    {
        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0.0f,1.0f),1.1f,0));
        pos.z = 0.0f;
        Instantiate(poop[Random.Range(0,5)], pos, Quaternion.identity);
    }
}
