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
            // 마우스 클릭 시
            this.startPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // 마우스에서 떼었을 때
            Vector2 endPos = Input.mousePosition;
            float swipeLength = endPos.x - this.startPos.x;
            // 스와이프의 길이를 처음 속도로 변경한다? 이게 뭐지
            this.speed = swipeLength / 2500.0f;
            // 스와이프 길이를 초기 속도로 설정하려고 500.0으로 나누었다는데... 177p
            this.GetComponent<AudioSource>().Play();
        }

        transform.Translate(this.speed, 0, 0);
        this.speed *= 0.98f;
        // translate는 인수값만큼 이동시키는 메서드로, 상대적인 이동 값을 나타낸다.
        // ex translate(2,0,0)이면 x축 방향으로 2만큼 이동한다는 의미
        // 월드 좌표계 : 오브젝트가 게임판 어디에 있는지, 로컬 좌표계는 게임 오브젝트가 개별적으로 갖는 좌표계
        // translate는 로컬 좌표계이다! 오브젝트가 회전하면서 동시에 이동할 때에는 조심해야 한다.

    }
}
