using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    float speed = 0;
    Vector2 startPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // ���콺 Ŭ�� ��
            this.startPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // ���콺���� ������ ��
            Vector2 endPos = Input.mousePosition;
            float swipeLength = endPos.x - this.startPos.x;
            // ���������� ���̸� ó�� �ӵ��� �����Ѵ�? �̰� ����
            this.speed = swipeLength / 2500.0f;
            // �������� ���̸� �ʱ� �ӵ��� �����Ϸ��� 500.0���� �������ٴµ�... 177p
            this.GetComponent<AudioSource>().Play();
        }

        transform.Translate(this.speed, 0, 0);
        this.speed *= 0.98f;
        // translate�� �μ�����ŭ �̵���Ű�� �޼����, ������� �̵� ���� ��Ÿ����.
        // ex translate(2,0,0)�̸� x�� �������� 2��ŭ �̵��Ѵٴ� �ǹ�
        // ���� ��ǥ�� : ������Ʈ�� ������ ��� �ִ���, ���� ��ǥ��� ���� ������Ʈ�� ���������� ���� ��ǥ��
        // translate�� ���� ��ǥ���̴�! ������Ʈ�� ȸ���ϸ鼭 ���ÿ� �̵��� ������ �����ؾ� �Ѵ�.

    }
}
