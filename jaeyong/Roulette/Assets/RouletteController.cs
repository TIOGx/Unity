using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteController : MonoBehaviour
{
    float rotspeed = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.rotspeed = 5;
        }
        transform.Rotate(0, 0, this.rotspeed);
        // x, y, z ������ ȸ���ϴ� ��. x������ ȸ���������� ��� �ɱ�? => �� �Ʒ��� �ڹٲ�� ���ư��ڰ�
        // y������ ȸ���ϸ� �� ������ó�� ���ư� ���̰�, z������ ȸ���ϸ� �ð�������� ���ư�����?
        // ���⼭ �߿��� �� : �μ��� �����ϴ� ȸ�� ���� ����� �ð� �ݴ����, ������ �ð����
        this.rotspeed *= 0.96f;
    }
}
