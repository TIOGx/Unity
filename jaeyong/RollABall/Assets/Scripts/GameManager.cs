using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public int totalItemCount;
    public int stage;
    public Text StageText;
    public Text PlayerText;

    private void Awake()
    {
        StageText.text = "/ " + totalItemCount;
    }
    public void GetItem(int count)
    {
        PlayerText.text = count.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            SceneManager.LoadScene("level" + stage);
        }
    }
}
