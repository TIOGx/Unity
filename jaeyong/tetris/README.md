# Tetris

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
5, 9가 false이므로 y는 9, -0.4f
5, 8이 false이므로 y는 8, -0.8f
5, 7이 false이므로 y는 7, -1.2f
...6 16 5 2 4 2.4 3 2.8 2 3.2
5, 2가 false이므로 y는 2, -3.2f
5, 1이 false이므로 y는 1, -3.6f
5,0이 true이므로 sync로 들어가게 된다.

이렇게 똑같이 -3.6f로 진행하게 되야하는데 처음에는 while문을 나오면서 y++을 해주어야 한다고 생각하여 한 칸이 더 띄워지는 상황이 발생했다. 
코드를 짤 때 한 줄 한 줄 직관적으로 짜야 이런 오류가 발생하지 않을 것이라고 느꼈다. 이 한 줄 떄문에 한시간을 넘게 고민하였다... 
