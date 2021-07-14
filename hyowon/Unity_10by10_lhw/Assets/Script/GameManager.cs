using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  [SerializeField]
  private TextMeshProUGUI ScoreTMPro;
  [SerializeField]
  private Image Timerbar;

  [SerializeField]
  private int GoalNum;

  [SerializeField]
  private RectTransform SelectField;
  [SerializeField]
  private GameObject GameOverCanvas;

  [SerializeField]
  private GameObject[] NumPrefab = new GameObject[9];
  private List<GameObject> Bubbles;
  private Dictionary<GameObject, int> CheckDict;
  private Camera Camera;


  private bool isDragging;
  private int sum, score;
  private float timer, MAX_TIMER;
  private Vector2 MouseInit, startSelectPos, endSelectPos, curSelectPos;

  private void Start()
  {
    Time.timeScale = 1;
    Camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    isDragging = false;
    GameOverCanvas.SetActive(false);
    SelectField.gameObject.SetActive(false);
    Bubbles = new List<GameObject>();
    GoalNum = 10;
    score = 0;
    sum = 0;
    MAX_TIMER = 90f;
    timer = MAX_TIMER;
    SettingBoard();
  }

  private void Update()
  {
    //test key
    if (timer > 0)
    {
      timer -= Time.deltaTime;
      Timerbar.fillAmount = timer / MAX_TIMER;

      if (Input.GetKey(KeyCode.F))
      {

      }

      if (Input.GetMouseButtonDown(0))
      {
        CheckDict = new Dictionary<GameObject, int>();
        MouseInit = Input.mousePosition;
        startSelectPos = Camera.ScreenToWorldPoint(MouseInit);
      }

      if (Input.GetMouseButton(0))
      {
        SelectField.gameObject.SetActive(true);
        curSelectPos = Camera.ScreenToWorldPoint(Input.mousePosition);
        MouseDrag(Input.mousePosition);
        ChangeBubblesColor(curSelectPos);
      }

      if (Input.GetMouseButtonUp(0))
      {
        MouseInit = Input.mousePosition;
        endSelectPos = Camera.ScreenToWorldPoint(MouseInit);
        SelectBubbles(endSelectPos);
        SelectField.gameObject.SetActive(false);
        UndoBubbles();


        foreach (KeyValuePair<GameObject, int> el in CheckDict)
        {
          sum += CheckDict[el.Key];
        }
        Debug.Log(sum);
        if (sum == GoalNum)
        {
          foreach (KeyValuePair<GameObject, int> el in CheckDict)
          {
            Destroy(el.Key);
            Bubbles.Remove(el.Key);
          }
          score += CheckDict.Count;
          ScoreTMPro.text = score.ToString();
        }
        sum = 0;
      }
    }
    else
    {
      Time.timeScale = 0;
      GameOverCanvas.SetActive(true);
    }

  }

  private void SettingBoard()
  {
    // x : -7 ~ 7
    // y : -4 ~ 4
    // int startPos_X = -7, startPos_Y = 4;
    for (float i = 4; i > -4; i -= 0.8f)
    {
      for (float j = -7; j < 8; j += 0.8f)
      {
        GameObject bubble = (GameObject)Instantiate(NumPrefab[Random.Range(0, 9)],
        new Vector2(j, i),
        Quaternion.identity);
        Bubbles.Add(bubble);
      }
    }

  }

  private void MouseDrag(Vector2 curMousePos)
  {
    SelectField.gameObject.SetActive(true);
    float width = curMousePos.x - MouseInit.x;
    float height = curMousePos.y - MouseInit.y;

    SelectField.sizeDelta = new Vector2(Mathf.Abs(width), Mathf.Abs(height));
    SelectField.anchoredPosition = MouseInit + new Vector2(width / 2, height / 2);
  }
  private void ChangeBubblesColor(Vector2 curMousePos)
  {
    Vector2 max, min;
    Color32 preColor = new Color32(243, 125, 125, 255);
    Color32 postColor = new Color32(96, 149, 245, 255);
    if (startSelectPos.x > curMousePos.x)
    {
      max.x = startSelectPos.x;
      min.x = curMousePos.x;
    }
    else
    {
      max.x = curMousePos.x;
      min.x = startSelectPos.x;
    }
    if (startSelectPos.y > curMousePos.y)
    {
      max.y = startSelectPos.y;
      min.y = curMousePos.y;
    }
    else
    {
      max.y = curMousePos.y;
      min.y = startSelectPos.y;
    }
    Debug.Log(max);
    Debug.Log(min);
    Debug.Log("---");
    foreach (GameObject el in Bubbles)
    {
      Vector2 pos = el.transform.position;


      if (pos.x >= min.x && pos.x <= max.x
      && pos.y >= min.y && pos.y <= max.y)
      {
        el.transform.localScale = Vector3.Lerp(el.transform.localScale, new Vector3(5f, 5f, 0), Time.deltaTime * 10);
        el.transform.GetChild(0).GetComponent<SpriteRenderer>().color = postColor;
      }
      else
      {
        el.transform.localScale = Vector3.Lerp(el.transform.localScale, new Vector3(4, 4, 0), Time.deltaTime * 10);
        el.transform.GetChild(0).GetComponent<SpriteRenderer>().color = preColor;
      }
    }
  }

  private void SelectBubbles(Vector2 curMousePos)
  {
    Vector2 max, min;
    Color32 preColor = new Color32(243, 125, 125, 255);
    Color32 postColor = new Color32(96, 149, 245, 255);
    foreach (GameObject el in Bubbles)
    {
      Vector2 pos = el.transform.position;
      if (startSelectPos.x > curMousePos.x)
      {
        max.x = startSelectPos.x;
        min.x = curMousePos.x;
      }
      else
      {
        max.x = curMousePos.x;
        min.x = startSelectPos.x;
      }
      if (startSelectPos.y > curMousePos.y)
      {
        max.y = startSelectPos.y;
        min.y = curMousePos.y;
      }
      else
      {
        max.y = curMousePos.y;
        min.y = startSelectPos.y;
      }

      if (pos.x >= min.x && pos.x <= max.x
      && pos.y >= min.y && pos.y <= max.y)
      {
        el.transform.localScale = Vector3.Lerp(el.transform.localScale, new Vector3(5f, 5f, 0), Time.deltaTime * 10);
        el.transform.GetChild(0).GetComponent<SpriteRenderer>().color = postColor;

        if (!CheckDict.ContainsKey(el))
        {
          CheckDict.Add(el, int.Parse(el.name.Split('_')[1].Split('(')[0]));
        }
      }
      else
      {
        el.transform.localScale = Vector3.Lerp(el.transform.localScale, new Vector3(4, 4, 0), Time.deltaTime * 10);
        el.transform.GetChild(0).GetComponent<SpriteRenderer>().color = preColor;
      }
    }
  }

  private void UndoBubbles()
  {
    Color32 preColor = new Color32(243, 125, 125, 255);
    foreach (GameObject el in Bubbles)
    {
      el.transform.localScale = new Vector3(4f, 4f, 0);
      el.transform.GetChild(0).GetComponent<SpriteRenderer>().color = preColor;
    }
  }

  public void GotoLobby()
  {
    SceneManager.LoadScene("LobbyScene");
  }

}
