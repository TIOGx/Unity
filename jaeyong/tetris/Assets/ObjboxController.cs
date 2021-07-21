using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjboxController : MonoBehaviour
{
    [SerializeField]
    private GameObject tile;
    [SerializeField]
    private GameObject objbox;
    [SerializeField]
    private GameObject ground;
    private Vector3 premove;
    private float topy = 14.5f;
    private float topx = 8f;
    private float maxtimer = 1.0f;
    private float timer = 0.0f;
    private bool bar = false;
    private int r = -1;
    private bool[,] visit = new bool[9, 15];

    // -4.74~y~4.74 , -2.56~x~2.56, �� y��ǥ�� �� �� �ִ� Ÿ�� ���� 11��
    // �� ĭ�� �����ϴ� ���� ) 0.5

    bool checkerror()
    {
        for(int i=0;i<4;i++){
            Transform tf = objbox.transform.GetChild(i).transform;
            if((int)Mathf.Round(tf.position.x) < 0 || (int)Mathf.Round(tf.position.x) > topx){
                Debug.Log("범위 벗어남");
                return true;
            } if((int)Mathf.Round(tf.position.y) < 0 || (int)Mathf.Round(tf.position.y) > topy){
                Debug.Log("범위 벗어남2");
                return true;
            }
            if(visit[(int)Mathf.Round(tf.position.x), (int)Mathf.Round(tf.position.y)]){
                Debug.Log("블러기 존재함");
                return true;
            }
        }
        return false;
    }
    void Gobackground()
    {
        for (int i = 0; i < 4; i++)
        {
            if (objbox.transform.childCount > 0)
            {
                Transform tf = objbox.transform.GetChild(0).transform;
                Vector3 pos = tf.transform.position;
                visit[(int)Mathf.Round(pos.x), (int)Mathf.Round(pos.y)] = true;
                tf.name = (int)Mathf.Round(pos.x)+","+(int)Mathf.Round(pos.y);
                tf.transform.SetParent(ground.transform, true);
            }

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<9;i++){
            for(int j=0;j<15;j++){
                visit[i,j] = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > maxtimer)
        {
            Debug.Log("ya" + objbox.transform.position);
            timer = 0;
            objbox.transform.Translate(0, -1f, 0, Space.World);
            if(checkerror()){
                objbox.transform.Translate(0, 1f, 0, Space.World);
                Gobackground();
                GameObject.FindWithTag("Generator").GetComponent<TileGenerator>().CreateTet();
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && r != 3)
        {
            if (r == 1 && bar == false)
            {
                objbox.transform.RotateAround(objbox.transform.position, new Vector3(0, 0, 1), 90f);
                bar = true;
                if(checkerror()){
                    objbox.transform.RotateAround(objbox.transform.position, new Vector3(0, 0, 1), -90f);
                    bar = false;
                }
            }
            if (r == 1 && bar == true)
            {
                objbox.transform.RotateAround(objbox.transform.position, new Vector3(0, 0, 1), -90f);
                bar = false;
                if(checkerror()){
                    objbox.transform.RotateAround(objbox.transform.position, new Vector3(0, 0, 1), 90f);
                    bar = true;
                }
            }
            objbox.transform.RotateAround(objbox.transform.position, new Vector3(0, 0, 1), 90f);
            if (checkerror())
            {
                objbox.transform.RotateAround(objbox.transform.position, new Vector3(0, 0, 1), -90f);
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            objbox.transform.Translate(-1f, 0, 0, Space.World);
            if(checkerror()){
                objbox.transform.Translate(1f, 0, 0, Space.World);
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            objbox.transform.Translate(1f, 0, 0, Space.World);
            if(checkerror()){
                objbox.transform.Translate(-1f, 0, 0, Space.World);
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            objbox.transform.Translate(0, -1f, 0, Space.World);
            if(checkerror()){
                objbox.transform.Translate(0, 1f, 0, Space.World);
            }
        }
    }
}
