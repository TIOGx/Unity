using UnityEngine;
using System.Collections;

public class ParticleController : MonoBehaviour
{
    private ParticleSystem ps;
    private float timer = 0f;
    private float save = 0f;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        timer = ps.duration;
    }

    void Update()
    {
        save += Time.deltaTime;
        if(save > timer)
        {
            Debug.Log("��ƼŬ��Ʈ����");
            Destroy(ps.gameObject);
        }
    }
}