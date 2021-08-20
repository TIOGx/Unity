# Tetris

![ezgif com-gif-maker](https://user-images.githubusercontent.com/22047551/127613776-e817d925-684d-4ab6-80fb-ec2f5fc71206.gif)

## 2021 07 22
테트리스 완성!  
큰 흐름은 테트리스 블럭을 Generator에서 생성하고 visit이란 이름의 2차원 배열을 통해 이미 블럭이 존재하는지 체크하고 움직일 수 있는지 확인하게 된다.  
블럭이 쌓일때 checkground() `if(col.childCount == 9)` 를 통하여 한 행 가득하게 블럭이 차 있는지 확인하게 된다.  
가득 차 있다면 gameObject에 대한 destroy를 진행하고 해당하는 2차원 배열을 false로 만들어준다.  
그 후 checkclean(idx)를 넘겨 삭제했던 행부터 위에 있는 행들을 한칸씩 내려주는 작업을 진행하게 된다.  
이 때 가장 어려웠던 점은 foreach문이 반복을 진행하게 되면 진행했던 전 단계로 다시 back하는것이 어려웠고, foreach 대신 for문을 사용하여 조건변수를 내려줌으로써 다시 전단계부터 실행이 되게 만들었다. (checkground함수)  
col.DetachChildren()은 부모 자식 관계를 끊어주는것으로써 destroy가 느리게 진행 될 경우를 생각하여 미리 배제하고 신경쓴다는 개념에서 사용하게 되었다.

## 2021 07 21

같은 팀원의 도움으로 x,y 0,0부터 시작하기 위하여 카메라 사이즈와 백그라운드의 스케일을 바꾸면서 0,0이 왼쪽 아래가 되게 만들었다.
![image](https://user-images.githubusercontent.com/22047551/126459626-2cece7a1-dfd6-4bc2-9972-e884ac8c7e99.png)  
그 후 이동을 하고 만약 이동한 좌표가 조건을 일치하지 않는다면 뒤로 돌려주는 (ctrl + z 느낌)으로 테트리스 블록의 움직임을 구성하였고, 테트리스 블록에 대해 회전이 일어날 때 부모오브젝트에 비하여 자식오브젝트는 x좌표 y좌표, 스케일까지 변경되었다. 이것을 게임을 진행하며 디버깅을 통하여 이해했고 이것에 대해 방지해주기 위하여 '반올림' - Mathf.Round를 사용했다. 
하지만 테트리스를 제작 중에 어떻게 행을 삭제하여야 할지에 대해 고민이 되었다. 대부분은 transform을 이용하여 transform을 destroy해주는 방법으로 진행이 되었고, destroy는 각각의 컴포넌트에 대해도 파괴가 가능하다. 이름을 이용하여 `tf.name = (int)Mathf.Round(pos.x)+","+(int)Mathf.Round(pos.y);` 빈 오브젝트에 넣음으로써 그 오브젝트를 확인하고, 삭제를 판단하는데 수많은 비교가 필요하고 해당하는 행을 삭제하게 되면 그 후에 바꿔줘야하는 위치나 이런것들에 대한 고민이 있어서 아직 삭제를 구현하진 못했다.

오늘 스터디가 있기 때문에 게임 스터디가 끝난 후에 어떻게 삭제를 진행하여야 할지 아이디어를 얻어서 한번 구현해봐야 겠다.  
꼭 마무리하겠다.

## 2021 07 17
일단  함수들을 알려주자면

```CS
 bool check()
    {
        for(int i = 0; i < 4; i++)
        {
            Transform tf = objbox.transform.GetChild(i).transform;
            if (tf.position.x < -topx || tf.position.x > topx || tf.position.y < -topy)
            {
                Debug.Log("너 꽉차있잖아");
                return false;
            }
        }
        return true;
    }
    void Gobackground()
    {
        for (int i = 0; i < 4; i++)
        {
            if(objbox.transform.childCount >= 0)
            {
                Transform tf = objbox.transform.GetChild(0).transform;
                tf.transform.SetParent(background.transform, true);
            }
            
        }
    }
```
으로 check함수를 이용하여 더 이상 진행할 수 없다고 판단이 되면 Gobackground()를 실행하게 된다.  
GetChild를 이용하여 한 부모(objbox)안에 함께 하던 Tile 프리팹 자식들을 background로 보내주었다.   
  
여기서 중요한 점 : 내가 tf를 Setparent로 background로 보내주면 objbox의 child의 인덱스 값이 요동친다.  
ex) 0,1,2,3이 존재했는데 내가 0을 background의 자식으로 보냈다면, 1,2,3이 0,1,2로 다시 바뀐다.  
따라서 **GetChild(0).transform**으로 background에게 보내주어야 함



## 2021 07 16
200줄 가량 코딩을 하였음에도 불구하고 정상적인 회전이나, 작동에서 어려움을 보였다. Code 안에서 반복되는 줄들은 함수로 재사용성을 높여야하는데 재사용성뿐만 아니라 가독성도 떨어지게 되었다.
생각을 다시 정리하여 코드를 재작성해야겠다. 
> 생각 정리
1. 있어야하는 오브젝트들 : objbox, background, tile
2. Tile들이 네개가 모여 한 블럭(block)을 구성하게 만듦.
3. 한 블럭들은 objbox라는 부모 GameObject에 담김.
4. 블럭의 위치가 고정되면 맵의 background에 블럭 위치를 남김.
5. 현재 움직이는 오브젝트는 bjbox에 이미 자리가 고정된 오브젝트는 background에
> 이렇게 하는 이유는 objbox를 회전시킬때 background를 objbox에 함께 두었을 때 문제가 일어남.
> background에서 y 좌표값을 부모로) x좌표값을 자식으로 object를 만들어 object가 모든 x좌표에 존재한다면 모든 자식 삭제
6. z축을 축으로 회전하기 전에는 y에 -0.4f해주던 것이 회전을 진행시키면 x축으로 -0.4f씩 이동이 된다.
6-1. 하지만 Translate에 **Space.World**를 이용하면 축 이동 없이 내가 원하는 방향으로 내려감.
7. (0,0)부터 unity 좌표를 시작할 수 있는 방법이나. 내가 따로 변수로 두어서 시작하는 방법들이 있을 듯
8. 내일 목표 : 나만의 좌표를 통해 타일 몇개가 들어갈 수 있을지 생각해서 직접 넣어보기. transform에서 localPosition 을 사용하면 좀 더 간편하게 나타낼 수 있지않을까?
> https://docs.unity3d.com/kr/530/ScriptReference/Transform.html

objbox에서 해야하는 일 : 타일을 네개 생성하기, 상하좌우로 이동할 수 있는지 Check하고 Update를 통해서 좌표 이동하기, 회전하기
background에서 해야하는 일 : 백그라운드에 넣어줄 때마다 y값(부모)에 x값(자식)들 Check하기, objbox에서 좌표 받아서 background에 넣기


## 2021 07 15

```CS
if (Input.GetKeyDown(KeyCode.Space))
{
    while(visit[x, y-1] == false)
    {
        cnt++;
        y--;
        
    }
    // y++;
    obj.transform.Translate(0, -0.4f * cnt,0);
    timer = 0;
    cnt = 0;
    sync();
    
}
```
실행추적 :
x= 5, y= 10, cnt = 0인 상태로 게임을 시작하게 되는데, Spacebar를 누르게 되면 while문으로 들어가 
1) 5,9 false이므로 cnt는 1, y는 9가 된다.
2) 5,8 false이므로 cnt는 2, y는 8이 된다.
3) 5,7 false이므로 cnt는 3, y는 7이 된다.
4) 5,6 false이므로 cnt는 4, y는 6이 된다.
5) 5,5 false이므로 cnt는 5, y는 5가 된다.
6) 5,4 false이므로 cnt는 6, y는 4가 된다.
7) 5,3 false이므로 cnt는 7, y는 3이 된다.
8) 5,2 false이므로 cnt는 8, y는 2가 된다.
9) 5,1 false이므로 cnt는 9, y는 1이 된다.
이때 5,0은 true이기 때문에 while문에 들어가지 않고, 0, -3.6f, 0 만큼 translate한다.
만약 space를 누르지 않았더라도

```CS
if(timer > maxtimer)
{
    timer = 0;
    if (visit[x, y-1] == false)
    {
        y--;
        obj.transform.Translate(0, -0.4f, 0);

    } else
    {
        sync();
    }
}
```
1) 5, 9가 false이므로 y는 9, -0.4f
2) 5, 8이 false이므로 y는 8, -0.8f
3) 5, 7이 false이므로 y는 7, -1.2f  
...
8) 5, 2가 false이므로 y는 2, -3.2f
9) 5, 1이 false이므로 y는 1, -3.6f
5,0이 true이므로 sync로 들어가게 된다.

이렇게 똑같이 -3.6f로 진행하게 되야하는데 처음에는 while문을 나오면서 y++을 해주어야 한다고 생각하여 한 칸이 더 띄워지는 상황이 발생했다. 
코드를 짤 때 한 줄 한 줄 직관적으로 짜야 이런 오류가 발생하지 않을 것이라고 느꼈다. 이 한 줄 떄문에 한시간을 넘게 고민하였다... 
