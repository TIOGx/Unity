using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    void Update(){
        if(Input.GetMouseButtonDown(0)){
            LoadGame();
        }
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
