using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using Cinemachine;

public class PlayerScript : MonoBehaviourPunCallbacks, IPunObservable
{
    public Rigidbody2D RB;
    public Animator AN;
    public SpriteRenderer SR;
    public PhotonView PV; // 자기 컴포
    public Text NickNameText;
    public Image HealthImage;
    bool isGround;
    Vector3 curPos;
    void Awake()
    {
        NickNameText.text = PV.IsMine ? PhotonNetwork.NickName : PV.Owner.NickName; // Control Locally가 true, false 인 것이 PV.IsMine과 비슷하게 작용
        NickNameText.color = PV.IsMine ? Color.green : Color.red;

        if (PV.IsMine)
        {
            var CM = GameObject.Find("CMCamera").GetComponent<CinemachineVirtualCamera>();
            CM.Follow = transform;
            CM.LookAt = transform;
        }
    }

    [PunRPC]
    void FlipXRPC(float axis) => SR.flipX = axis == -1;
    void Update()
    {
        if (PV.IsMine)
        {
            float axis = Input.GetAxisRaw("Horizontal");
            RB.velocity = new Vector2(4 * axis, RB.velocity.y); // transform.translate는 벽을 자꾸 뚫을라고 해..
            if (axis != 0)
            {
                AN.SetBool("walk", true);
                PV.RPC("FlipXRPC",
                       RpcTarget.AllBuffered, // 기억해주는 것. 다음에 접속했을때도 내 상태가 유지되게?
                       axis);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                PV.RPC("JumpRPC", RpcTarget.All);
            }
            if (Mathf.Abs(RB.velocity.y) > 0)
            {
                AN.SetBool("jump", true);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {// 이것도 똑같이 Resources에 넣어놓고 Instantiate 해주는 것
                PhotonNetwork.Instantiate("Bullet", transform.position + new Vector3(SR.flipX ? -0.4f : 0.4f, -0.11f, 0), Quaternion.identity).GetComponent<PhotonView>().RPC("DirRPC", RpcTarget.All, SR.flipX ? -1 : 1);
                AN.SetBool("shoot", true);
            }
        }// 부드럽게 위치 동기화..
        else if ((transform.position - curPos).sqrMagnitude >= 100) transform.position = curPos; // 너무 멀리떨어졌다면 바로동기화
        else
        {
            transform.position = Vector3.Lerp(transform.position, curPos, Time.deltaTime * 10);
        }
    }
    [PunRPC] // 속력을 동기화시키고, 같은 포톤뷰를 가지고 있는 사람들에게 실행하라는 것.
    // RPC란? Remote Procedure Call로, 전체한테 이 함수를 넘겨주는게 아니라.
    // 나만의 Photon View ( A라는 플레이어의 PhotonView에서 이 RPC가 일어나면,
    // B라는 플레이어의 세상 안에 있던 A라는 플레이어의 PhotonView에서도 또한 일어남.
    void JumpRPC()
    {
        RB.velocity = Vector2.zero;
        RB.AddForce(Vector2.up * 700);
    }
    public void Hit()
    {
        HealthImage.fillAmount -= 0.1f;
        if (HealthImage.fillAmount <= 0)
        {// 비활성화 컴포넌트는 이렇게 세부적으로 찾아줘야 한다.
            GameObject.Find("Canvas").transform.Find("RespawnPanel").gameObject.SetActive(true);
            PV.RPC("DestroyRPC", RpcTarget.AllBuffered);
            // DestroyRPC는 플레이어든 총알이든 AllBuffered로 해야함. 복제 버그가 생김.
        }
    }
    [PunRPC]
    void DestroyRPC()
    {
        Destroy(gameObject);
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(HealthImage.fillAmount); // 넘겨주는 곳
        } else
        {
            curPos = (Vector3)stream.ReceiveNext();
            HealthImage.fillAmount = (float)stream.ReceiveNext();
        } // 변수 동기화
    }

}
