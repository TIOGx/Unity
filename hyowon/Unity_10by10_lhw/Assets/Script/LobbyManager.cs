using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{

  [SerializeField]
  private GameObject Circle;
  private float time;
  private void Start()
  {
    time = 0;
  }
  private void Update()
  {
    time += Time.deltaTime;
    if (time > 0.01f)
    {
      Circle.transform.Rotate(0, 0, 1f);
      time = 0;
    }
  }
  public void StartGame()
  {
    SceneManager.LoadScene("MainScene");
  }
}
