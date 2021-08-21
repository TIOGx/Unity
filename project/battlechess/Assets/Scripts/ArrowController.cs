using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour 
{
    public float dx;
    public float dz;
    public float Damage;
    void Start()
    {
        this.GetComponent<Rigidbody>().AddForce(new Vector3(dx, 0, dz) * 3, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider target)
    {
        if (target.tag != null)
        {
            if (target.tag != this.gameObject.tag)
            {
                target.gameObject.GetComponent<PieceController>().Damaged(Damage);
                Destroy(gameObject);
            }
        }
    }
}
