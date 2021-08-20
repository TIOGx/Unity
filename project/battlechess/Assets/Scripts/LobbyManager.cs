using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LobbyManager : MonoBehaviour
{
    private const float elapsedTime = 8f;
    private float timer = 0f;
    [SerializeField]
    private Text LoadText;
    private string Textstring;
    // Start is called before the first frame update
    IEnumerator LoadCoroutine()
    {
        
        for(int i = 0; i < 3; i++)
        {
            LoadText.text += ".";
            yield return new WaitForSeconds(2f);
        }
        yield break;
    }
    private void Start()
    {
        Textstring = LoadText.text;
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > elapsedTime)
        {
            LoadText.text = Textstring;
            StartCoroutine(LoadCoroutine());
            timer = 0f;
        }
        if(Input.GetMouseButtonDown(0)){
            SceneManager.LoadScene("GameScene");
        }
    }
}
