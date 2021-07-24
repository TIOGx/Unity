using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public float volumeScale;
    public AudioClip audioFire;
    public AudioClip audioHit;
    public AudioClip[] audioDie;
    AudioSource audioSource;
    void Awake(){
        this.audioSource = GetComponent<AudioSource>();
    }    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

///////////////////////////////////////////////////////////////////////////////////////////
    public void PlaySound(string action){ // 각 액션별 소리 저장 및 불러오기
        switch(action){
            case "Fire":
                audioSource.clip = audioFire;
                volumeScale = 0.1f;
                break;
            case "Hit":
                audioSource.clip = audioHit;
                volumeScale = 0.7f;
                break;
            case "Die":
                audioSource.clip = audioDie[Random.Range(0,2)]; // 죽는 소리 랜덤 재생
                volumeScale = 1f;
                break;
        }
        audioSource.PlayOneShot(audioSource.clip, volumeScale);
    }
}
