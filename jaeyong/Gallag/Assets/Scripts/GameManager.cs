using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Text ConUpgrade;
    [SerializeField]
    private GameObject t; // gameover 문구가 뜰떄 tle를 setactive 끄고 싶은데, canvas 타입으로? 겜오브젝트타입으루?
    [SerializeField]
    private GameObject GameOver; // 이것두 그래서 그냥 go로 둠.
    [SerializeField]
    private GameObject Pause;
    private int tmp = 0;
    public Text Scoretext;
    private int score = 0;
    private bool over = false;
    private bool pau = false;
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }
    private void Awake()
    {
        // DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        init();
    }
    IEnumerator DisCon()
    {
        ConUpgrade.enabled = true;
        yield return new WaitForSeconds(2f);
        ConUpgrade.enabled = false;
        yield break;
    }
    public void isGameOver()
    {
        Time.timeScale = 0;
        t.SetActive(false);
        GameOver.SetActive(true);
        over = true;
    }
    public void isPause()
    {
        if(over == false)
        {
            Time.timeScale = 0;
            Pause.SetActive(true);
            pau = true;
        }
        else
        {
            Debug.Log("죽었으면서 ESC를 왜 누르나 ?");
        }

    }
    public void addScore(int num)
    {
        score += num;
        Scoretext.text = score.ToString();
    }
    public int getScore()
    {
        return score;
    }
    public int getLevel()
    {
        return (int)(score / 50)+1;
    }
    // Update is called once per frame
    void Update()
    {
        if((tmp = getScore()) % 50 == 0 && tmp != 0)
        {
            
            StartCoroutine(DisCon());
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(pau == false)
            {
                isPause();
            } else
            {
                SceneManager.LoadScene("LobbyScene");
            }
        }
        /* game over */
        if (Input.GetKeyDown(KeyCode.R) && over == true)
        {
            over = false;
            Time.timeScale = 1;
            score = 0;
            SceneManager.LoadScene("MainScene");

        }
        /* 일시중지와 관련된 code */
        if (Input.GetKeyDown(KeyCode.R) && pau == true)
        {
            Pause.SetActive(false);
            pau = false;
            Time.timeScale = 1;
        }
    }
    public void init()
    {
        score = 0;
        pau = false;
        over = false;
        Time.timeScale = 1;
    }
}
