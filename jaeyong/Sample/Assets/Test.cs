using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private int hp = 100;
    private int power = 50;
    public void Attack()
    {
        Debug.Log(this.power + "������� ������.");
    }
    public void Damage(int damage)
    {
        this.hp -= damage;
        Debug.Log(damage + "������� �Ծ���.");
    }
}
public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Player MyPlayer = new Player();
        MyPlayer.Attack();
        MyPlayer.Damage(30);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
