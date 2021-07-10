재훈형의 게임 코드리뷰를 진행하면서 일단 생각보다 스크립트가 적은게 되게 신기하였다. 스크립트 하나에 많은 역할이 부여돼서 그런 것일까? 지금까지 봐왔을 때 항상 존재했던 GameDirector같은것 또한 없었고, GameManager가 Director의 역할까지 진행할 것이라고 생각이 들었다.

# LobbyScene

천천히 로비씬부터 살펴보자.

첫번째로 **Canvas** UI의 폰트가 처음 보는 폰트임에 어떤 컴포넌트가 추가되었는지 궁금하였고 저번주 스터디시간에 언급되었던 **Canvas 내 Title**을 확인하여보니 TextMeshProUGUI를 이용하여 Font를 적용시키고 있었다. 
두번째로 **StartButton**에 On Click() 내장 메소드를 이용하여 LobbyManager.StartGame() 메소드를 불러오는 것을 확인하였고 
세번째 오브젝트 **EventSystem**이 어떤 역할을 하는지 이해할 수 없었다. EventSystem은 키보드, 마우스, 터치 및 사용자의 입려에 따라 응용프로그램의 오브젝트에 이벤트를 보내는 방법이라고 한다. (공식 문서 참조)
삭제를 해보니 게임 스타트에 대한 input을 받지 못했고 아마 자동적으로 생성되는 기본 Manager라고 생각이 되었다. 
마지막으로 **LobbyManager**에 대해서 코드 리뷰를 진행해 보겠다. UI를 사용함에 따라 `using UnityEngine.UI`와 Scene 이동에 `using UnityEngine.SceneManagement`를 이용하였다. SerializeField이 바로 보였는데, 이것은 private 변수를 인스펙터에서 접근가능하게 해줌으로써 오브젝트나 컴포넌트를 연결할 때 인스펙터에서만 관리하게 하는데에 의의가 있는 field이다. 당연히 private임에 외부 스크립트가 수정하거나 참조할 수 없다.

코드 중 Update() 메소드에 
``` CS
private void Update()
  {
    time += Time.deltaTime;
        /*if (time > 0.01f)
        {
          Circle.transform.Rotate(0, 0, 1f);
          time = 0;
        }*/
    }
    public void StartGame()
  {
    SceneManager.LoadScene("MainScene");
  }
}
```
주석문이 원래는 주석이지 않았는데, 변경해도 아무런 일이 일어나지 않았다. Inspector 안 컴포넌트에서 circle에 대한 이미지를 추가할 수 있었지만 구현되어 있지 않은 것 같아서 코드를 주석처리하였다.

이렇게 LobbyManager.cs와 LobbyScene에 대한 분석을 마친다.

# GameScene

GameManager.cs를 먼저 확인하게 되었다.

첫번째 오브젝트 GameManager
**using TMPro**를 사용한것으로 미루어 보아, TextMeshProUGUI를 오브젝트로 사용했다는 것을 알게 되었고 List와 Dictionary를 이용한 것은 다양한 Bubble들의 값이 10인지 체크하는 부분에서 사용된다고 생각이 들었다.
처음 시작시에 **Start() 메소드**부터 살펴보자.
Time.timeScale = 1; 을 사용한 이유는 게임이 실제 시간과 동일하게 흘러가게 함이고, isDragging은 추후에 true와 false를 번갈아가며 사용할 계획처럼 느껴졌다.
SetActive는 Inspector에 체크할 수 있고 체크를 풀 수 있는데. 체크 활성화는 존재하는 것을 그대로 존재하게 하는 것과 체크 비활성화는 존재하지만 없는 것처럼 해주는 것이다.
max_timer나 다양한 변수들을 초기화해주는 부분이다. SettingBoard() 메소드를 실행시키니 **SettingBoard() 메소드**에 대해 알아보자.
좌표를 이용하여 bubble프리팹을 만드는데, 프리팹에 적용되는 매개변수들이 특이하였다. Random.Range는 본 적이 있고 이렇게 인자를 받는 프리팹은 처음보았다. 프리팹이 인자를 받는다기보다는 Instantiate가 인자를 많이 받는다고 생각이 들었고 찾아보니 첫번째 인자는 오브젝트, 두번째는 생성 위치(vector j,i), 세번째는 생성시 회전 값이라고 한다.
아마 좌표마다 프리팹을 생성해주기 위하여 이렇게 코드를 구현한 것 같았다.
이제 **Update**를 살펴보자.
Time.deltaTime이 늘을때마다 fillAmount가 감소되고, F키를 받으면 아마 무언가 하고싶었는데 하다 만 것 같다. 마우스 버튼을 눌렀을 때와 누르고 있을 때, 마우스 버튼을 뗐을 때에 대한 각각의 함수가 진행되었다.
Input.mousePosition의 반환값이 벡터(좌표)임에도 불구하고 상대적 좌표이기 때문에, Camera.ScreenToWorldPoint를 사용하였다. 처음에는 Input.mousePosition을 그대로 사용하면 안되나?라는 생각을 하여서 바꿔서 진행해보았지만 오른쪽위의 앵커로부터 좌표들을 생각하여 드래그가 이상하게 되는 현상이 일어났다. ScreenToWorldPoint로 좌표를 얻어 버블을 선택할 때 메소드를 확인하고 싶어 update 안의 SelectBubble을 살펴보게 되었다.
이 전에, MouseDrag 먼저 살펴보자. MouseDrag는 SelectField를 이용하여(UI 중 하나로 우리가 드래그할 때 나오는 상자) active를 활성화시켜주고, width와 height를 이용하여 sizeDelta 함수와 anchoredPosition으로 값을 바꾸어준다.
**SelectBubble**은 Bubbles 안의 버블들을 전부 확인하면서 min, max 값을 구하고 있었는데, 이 식을 절대값을 이용하면 되지 않나? 라는 생각이 들었다. 일일히 구하는 것 보다 선택되지 않고 선택된 것을 구분하는게 좀 더 편한 방법이 있을 거라는 생각이 들어서 찾아보게 되었다.
또한 localScale을 바꿔주는데에 있어 선형보강법(Lerp)를 사용하였고, 첫번째 인자는 처음 크기, 두번째 인자는 변경하게 될 인자, 세번째 인자는 걸리는 시간으로 보통 위치를 바꾸는데에 많이 사용하는데 이 방법을 사용한것은 신기하게 느껴졌다.
if문에는 수 많은 버블 중에 드래그 영역 안에 포함된 버블들의 색깔을 늘리는 것이였고, 
드래그영역안에 포함되는 경우에는 Dictionary가 해당 bubble의 key를 가지고 있는지 확인하였고 만약 가지고 있지 않았다면, prefab의 이름에서 값을 parsing하여 checkdict에 넣어주는 과정을 거쳤다. => 매 번 새로운 버블이 선택될때마다 checkdict에 바로바로 넣어줌

이 후 마우스버튼을 떼면 UndoBubbles이 실행된다.
돌아가게 한 다음 sum을 체크하는 과정을 거치고, sum에 checkdict의 key값을 이용하여(gameobject) value값을 얻어 sum에 더해준다. 

궁금한 점 : ** destroy와 Bubble.Remove ** 를 통해서 Checkdict안에 있는 값도 사라진다. Key값이 사라지면 Checkdict 안의 <GameObject, Value>도 사라지는걸까?
