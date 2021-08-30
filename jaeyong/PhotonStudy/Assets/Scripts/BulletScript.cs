using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class BulletScript : MonoBehaviourPunCallbacks
{
    public PhotonView PV;
    int dir;
    // Start is called before the first frame update
    void Start() => Destroy(gameObject, 3.5f);

    // Update is called once per frame
    void Update() => transform.Translate(Vector3.right * 7 * Time.deltaTime * dir);

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground") PV.RPC("DestroyRPC", RpcTarget.AllBuffered);
        if(!PV.IsMine && other.tag == "Player" && other.GetComponent<PhotonView>().IsMine) // 내 포톤뷰가 아니면서(내총알이 아니면서), Trigger 일어난 게 나 자신이라면 Hit();
        {
            other.GetComponent<PlayerScript>().Hit();
            PV.RPC("DestroyRPC", RpcTarget.AllBuffered); // 여기서 RPC를 쓴 이유는, 내 화면에서만 삭제되는 것이 아닌 모든 뷰에서 삭제되어야 하기 때문에.
        }
    }

    [PunRPC]
    void DirRPC(int dir) => this.dir = dir;

    [PunRPC]
    void DestroyRPC() => Destroy(gameObject);
}
