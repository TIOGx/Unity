using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    Rigidbody rigid;
    bool isJump;
    AudioSource audio;
    public int itemCount;
    public GameManager manager;
    // Start is called before the first frame update
    void Awake()
    {
        isJump = false;
        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal"); // Raw는 0, -1, 1로 떨어집니다.
        float v = Input.GetAxisRaw("Vertical");
        Vector3 vec = new Vector3(h, 0, v);
        rigid.AddForce(vec, ForceMode.Impulse);

    }
    private void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJump)
        {
            isJump = true;
            rigid.AddForce(new Vector3(0, 30, 0), ForceMode.Impulse);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            isJump = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            itemCount++;
            audio.Play();
            other.gameObject.SetActive(false);
            manager.GetItem(itemCount);
        } else if (other.gameObject.tag == "finish")
        {
            if(itemCount == manager.totalItemCount)
            {
                SceneManager.LoadScene("Level"+(manager.stage+1).ToString());
            } else
            {
                SceneManager.LoadScene("Level"+(manager.stage).ToString());
            }
        }
    }
}
