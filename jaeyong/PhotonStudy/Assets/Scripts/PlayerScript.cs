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
    public PhotonView PV; // �ڱ� ����
    public Text NickNameText;
    public Image HealthImage;
    bool isGround;
    Vector3 curPos;
    void Awake()
    {
        NickNameText.text = PV.IsMine ? PhotonNetwork.NickName : PV.Owner.NickName; // Control Locally�� true, false �� ���� PV.IsMine�� ����ϰ� �ۿ�
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
            RB.velocity = new Vector2(4 * axis, RB.velocity.y); // transform.translate�� ���� �ڲ� ������� ��..
            if (axis != 0)
            {
                AN.SetBool("walk", true);
                PV.RPC("FlipXRPC",
                       RpcTarget.AllBuffered, // ������ִ� ��. ������ ������������ �� ���°� �����ǰ�?
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
            {// �̰͵� �Ȱ��� Resources�� �־���� Instantiate ���ִ� ��
                PhotonNetwork.Instantiate("Bullet", transform.position + new Vector3(SR.flipX ? -0.4f : 0.4f, -0.11f, 0), Quaternion.identity).GetComponent<PhotonView>().RPC("DirRPC", RpcTarget.All, SR.flipX ? -1 : 1);
                AN.SetBool("shoot", true);
            }
        }// �ε巴�� ��ġ ����ȭ..
        else if ((transform.position - curPos).sqrMagnitude >= 100) transform.position = curPos; // �ʹ� �ָ��������ٸ� �ٷε���ȭ
        else
        {
            transform.position = Vector3.Lerp(transform.position, curPos, Time.deltaTime * 10);
        }
    }
    [PunRPC] // �ӷ��� ����ȭ��Ű��, ���� ����並 ������ �ִ� ����鿡�� �����϶�� ��.
    // RPC��? Remote Procedure Call��, ��ü���� �� �Լ��� �Ѱ��ִ°� �ƴ϶�.
    // ������ Photon View ( A��� �÷��̾��� PhotonView���� �� RPC�� �Ͼ��,
    // B��� �÷��̾��� ���� �ȿ� �ִ� A��� �÷��̾��� PhotonView������ ���� �Ͼ.
    void JumpRPC()
    {
        RB.velocity = Vector2.zero;
        RB.AddForce(Vector2.up * 700);
    }
    public void Hit()
    {
        HealthImage.fillAmount -= 0.1f;
        if (HealthImage.fillAmount <= 0)
        {// ��Ȱ��ȭ ������Ʈ�� �̷��� ���������� ã����� �Ѵ�.
            GameObject.Find("Canvas").transform.Find("RespawnPanel").gameObject.SetActive(true);
            PV.RPC("DestroyRPC", RpcTarget.AllBuffered);
            // DestroyRPC�� �÷��̾�� �Ѿ��̵� AllBuffered�� �ؾ���. ���� ���װ� ����.
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
            stream.SendNext(HealthImage.fillAmount); // �Ѱ��ִ� ��
        } else
        {
            curPos = (Vector3)stream.ReceiveNext();
            HealthImage.fillAmount = (float)stream.ReceiveNext();
        } // ���� ����ȭ
    }

}
