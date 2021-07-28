using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    void Update(){

    }
    public void LoadGame()
    {
        Debug.Log("게임 로드");
        SceneManager.LoadScene("GameScene");
    }
}
