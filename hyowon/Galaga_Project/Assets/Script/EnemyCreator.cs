using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    public bool isDelay;
    public float respawn;
    public int Difficulty;
    public GameObject[] Enemies;
    public List<GameObject> NowEnemies;
    void Start()
    {
        NowEnemies = new List<GameObject>();
    }

    void Update()
    {
        if(!isDelay){ // 코루틴을 통해 리스폰 딜레이에 따른 소환
            isDelay = true;
            Spawn();
            StartCoroutine(CountSpawnDelay());
        }
        
    }
    void Spawn(){
        GameObject _obj = Instantiate(Enemies[Random.Range(0,3)], transform.position + new Vector3(Random.Range(-2,3),0,0) , Quaternion.Euler(0,0,180)); // 몬스터가 랜덤으로 생성되어 랜덤한 위치에서 -y 축 방향으로 전진하도록 연출
        NowEnemies.Add(_obj);
        // switch(Difficulty){ // 난이도에 따른 생성되는 몬스터 수 변경
        //     case 1:
        //         Instantiate(Enemies[Random.Range(0,3)], transform.position + new Vector3(Random.Range(-2,3),0,0) , Quaternion.Euler(0,0,180)); // 몬스터가 랜덤으로 생성되어 랜덤한 위치에서 -y 축 방향으로 전진하도록 연출
        //         break;
        //     case 2:
        //         Instantiate(Enemies[Random.Range(0,3)], transform.position + new Vector3(Random.Range(-2,3),0,0) , Quaternion.Euler(0,0,180)); // 몬스터가 랜덤으로 생성되어 랜덤한 위치에서 -y 축 방향으로 전진하도록 연출
        //         Instantiate(Enemies[Random.Range(0,3)], transform.position + new Vector3(Random.Range(-2,3),0,0) , Quaternion.Euler(0,0,180)); // 몬스터가 랜덤으로 생성되어 랜덤한 위치에서 -y 축 방향으로 전진하도록 연출
        //         break;
        //     case 3:
        //     Instantiate(Enemies[Random.Range(0,3)], transform.position + new Vector3(Random.Range(-2,3),0,0) , Quaternion.Euler(0,0,180)); // 몬스터가 랜덤으로 생성되어 랜덤한 위치에서 -y 축 방향으로 전진하도록 연출
        //     Instantiate(Enemies[Random.Range(0,3)], transform.position + new Vector3(Random.Range(-2,3),0,0) , Quaternion.Euler(0,0,180)); // 몬스터가 랜덤으로 생성되어 랜덤한 위치에서 -y 축 방향으로 전진하도록 연출
        //     Instantiate(Enemies[Random.Range(0,3)], transform.position + new Vector3(Random.Range(-2,3),0,0) , Quaternion.Euler(0,0,180)); // 몬스터가 랜덤으로 생성되어 랜덤한 위치에서 -y 축 방향으로 전진하도록 연출
        //         break;
        // }
        // GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySound("Fire");
    }
    IEnumerator CountSpawnDelay(){
        yield return new WaitForSeconds(respawn);
        isDelay = false;
    }    
}
