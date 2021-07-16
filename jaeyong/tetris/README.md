# Tetris

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
