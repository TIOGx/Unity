# Roll - A - Ball

## Unity 3D Private Project

내가 공이 되어 움직이며 Item을 전부 먹고 결승 지점에 들어가면 새로운 Level이 불러와지는 3D 기본 움직임 및 회전에 대하여 공부하기 위한 개인 프로젝트


### 210803

Level 2 완성 및 UI 응용

쉬운 공 굴리기 3D 게임을 완성시켰다. gallag때 이용했던 방법으로 Collider와 충돌 이벤트가 발생하면 새로 신을 불러오는 방법으로 초기화를 시켜주었는데, gallag때에는 맵을 넘어가는 오브젝트들을 위 아래 collider를 두어 destroy시켰던 경험이 생각나서 비슷한 방법으로 진행하였다. 더 좋은 방법이 있는지 찾아보아야 겠다.

### 210802

계획 및 Level 1 완성

현재는 tutorial느낌으로 item을 어렵게 구현하지 않았다. 이번 주 안에 item을 먹기 힘든 지형으로 지형도 만져보고, 캐릭터의 움직임은 2D에서도 많이 다뤘듯이 다루니까 3D에서도 편히 다룰 수 있었다. 스크립트에 대한 역할분담을 확실하게 하는 방법에 대해서 알아보아야 할 것 같다.



### 210802 공부한 것 && ISSUE

공부한 것 : FixedUpdate, Update, LateUpdate 및 다양한 Collision을 사용해보며 2D떄 공부했던것에 대한 복기
Awake, Start, FixedUpdate, Update, LateUpdate 순으로 script가 동작한다. 코루틴은 업데이트와 lateUpdate 사이에서 동작하게 됨.

ISSUE : Script 역할 분담