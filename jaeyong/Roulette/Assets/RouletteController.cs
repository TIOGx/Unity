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
        // x, y, z 축으로 회전하는 것. x축으로 회전했을때는 어떻게 될까? => 위 아래가 뒤바뀌며 돌아가겠고
        // y축으로 회전하면 반 접힌것처럼 돌아갈 것이고, z축으로 회전하면 시계방향으로 돌아가겟지?
        // 여기서 중요한 점 : 인수에 전달하는 회전 값이 양수면 시계 반대방향, 음수면 시계방향
        this.rotspeed *= 0.96f;
    }
}
