# 10by10 리뷰 !

### 1. 게임 설명

    10by10 게임은 두 숫자의 합이 "10"이 되면 숫자가 사라지는 게임이다.
    플레이어는 60초 동안 합이 10이 되는 두 숫자를 드래그하며 게임을 진행한다.

-----

#### 2. 씬 1 - 게임 시작화면

<img width="250" alt="스크린샷 2021-07-12 오후 4 34 10" src="https://user-images.githubusercontent.com/43170505/125248421-fdbdb080-e32e-11eb-8138-af9109f7d17d.png">

BackgroundImage 오브젝트를 통해 배경을 넣었고 Canvas에서 제목과 버튼에 각각 글과 폰트를 적용.
EventSystem 오브젝트는 책에서도 한 번 다룬 적이 있었는데, 사용자 입력과 UI 부품을 중간에서 이어주는 오브젝트로 UI를 사용할 때 반드시 필요한 오브젝트이다. 

 <img width="176" alt="스크린샷 2021-07-14 오후 1 06 02" src="https://user-images.githubusercontent.com/43170505/125559545-f3d20c0e-759d-4146-a2e6-1ff589be754e.png">

또 Canvas의 StartButton에서 다음과 같이 버튼을 누르면 LobbyManager.cs의 StartGame()메소드가 호출되어 게임이 시작되도록 했음을 알 수 있었다.
 

#### LobbyManager.cs
LobbyManager라는 빈 오브젝트에 LobbyManager.cs를 적용하여 로비화면 스크립트가 들어갔다.
- 코드 분석
  - [SerializeField] <br> : 처음 보는 표현이었다. GameManager 스크립트에서도 많이 보였던 표현인데, 쉽게 private 변수여도 Inspector 창에서는 접근 가능하게 해주는 역할!
  - Start() 메소드<br> : 스크립트 실행시 time = 0으로 적용.
  - StartGame() 메소드<br> : MainScene으로 씬 전환을 하게 하는 메소드.
  
-----

#### 3. 씬 2 - 게임 진행화면

<img width="250" alt="스크린샷 2021-07-12 오후 4 34 54" src="https://user-images.githubusercontent.com/43170505/125248513-17f78e80-e32f-11eb-9af5-13249ad56887.png">


왼쪽 상단에 ScoreText와 Score, 상단의 타임바, 그리고 1~9까지의 숫자들이 랜덤으로 호출되는 프리팹들과 60초가 지난 후 게임이 오버되는 UI까지로 구성된다. 

시간이 가는동안 fillamount를 통해 상단의 타임바가 줄어듦을 표현

<img width="250" alt="스크린샷 2021-07-12 오후 4 33 32" src="https://user-images.githubusercontent.com/43170505/125248337-e7175980-e32e-11eb-8014-cc340983cc74.png">

60초가 지나면 새로운 Canvas가 생성되며, 여기서 gameover UI와, 로비로 돌아가는 버튼이 생긴다. 버튼의 원리는 위의 StartButton과 같다.

#### GameManager.cs
 스크립트는 GameManager라는 빈 오브젝트에 GameManager.cs로 적용되어있다.
  - start 메소드 
    - GameOverCanvas.SetActive(false) 를 통해 게임오버 화면 false로 설정. 보드를 호출.
  - update 메소드
    - 5장에서 배웠던 fill amount와 앵커포인트를 사용하여 timebar를 설정했다.
      
      <img width="187" alt="스크린샷 2021-07-14 오후 3 03 49" src="https://user-images.githubusercontent.com/43170505/125571182-c9beb9c7-4275-46af-8922-77c285c72861.png">
    - 마우스를 클릭한 순간 마우스의 x,y 좌표가 MouseInit에 저장. 그 위치를 `ScreenToWorldPoint`를 사용하여 startSelectPos에도 저장. (그냥 스크린 좌표로 대입해주면 오류 발생할 수 있음. 따라서 ScreenToWorldPoint를 사용해 월드좌표값으로 변환해주는 거라고 한다.)
    - 마우스를 누르고 있는 동안의 좌표로 MouseDrag, SelectBubbles 메소드 호출! 
    - 마우스에서 손을 뗀 순간, SelectField를 비활성화하고 UndoBubbles()를 호출한다.
      이때 버블들의 sum과 GoalNum을 비교하고, 합이 같다면 버블을 제거한다.
    - timer가 0이되면 게임오버 캔버스를 활성화. Time.timeScale = 0를 통해 시간을 일시정지한다. (반대는 Time.timeScale = 1)
  - SettingBoard 메소드
    - 가로 19, 세로 12의 보드를 만듦.
    - 버블을 랜덤하게 생성. Bubbles에 버블을 add
    - Quaternion.identity <- 회전이 필요없음을 의미 
  - MouseDrag 메소드
    - SelectField를 활성화
    - 가로 세로 넓이를 현재 x,y좌표에서 MouseInit 좌표를 빼서 계산한다. (절댓값 따로 붙여줘야함)
  - SelectBubbles 메소드
    - 버블을 선택했을 때 색과 크기를 바꿔주는 역할!
  - UndoBubbles 메소드
    - 버블 선택을 취소했을 때, 각 버블의 색을 Color32(243, 125, 125, 255)으로 다시 바꿔주고, 크기도 원래대로 돌려놓는 역할을 한다.
    

