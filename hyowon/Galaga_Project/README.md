
# [Unity] GALAGA 만들기
### 현 상태

<img src="https://user-images.githubusercontent.com/22341383/126863928-09d9961f-3583-4fb4-a66a-5cfb60e29d57.gif" width="40%">

### 진행도
1. 기능구현
    
    1) PlayerController
        - 플레이어의 움직임을 제어 : Move() 키보드의 입력을 통해 상하좌우로 이동: 필요한 파라미터 = 방향, 속도 
        - Map 밖으로 나가지 않도록 Camera.main.WorldToViewportPoint 를 활용하여 처리
        - 총알 발사를 제어 : Fire() 자동적으로 리로딩 속도와 power에 따라 총알 발사: 필요한 파라미터 reload delay , power
			    이때 총알의 딜레이를 코루틴으로 구현 
        - powerlevel에 따라 나가는 총알의 종류를 바꿈 bullet 객체 배열에 저장
    
    2) BulletController
        - 총알의 움직임을 제어 : AddForce
        - 총알의 데미지 제어
	      - 총알이 소멸되지 않는 문제는 border의 콜라이더 충돌 판정을 통해 해결
