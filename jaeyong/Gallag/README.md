# Gallag 개별 프로젝트

## 만드는 중 ISSUE
Coroutine은 Player의 총알에 적이 맞았을 때 적이 점차 사라지는것을 Coroutine을 이용할 생각(공식문서에 나와있는 fadeout과 비슷하게)  

Singleton 패턴은 GameManager에게 적용시킬 것

## 210726까지의 Script

- BackgroundScroll
> 백그라운드이미지를 지속적으로 움직이게 SpriteRenderer의 material yoffset을 조금씩 바꿔주는 script로서 mainscene뿐만 아니라 lobbyscene에서도 쓸 수 있게 script화 함.

- EnemyGenerator
> 적을 생성하는 script파일으로 Enemy 프리팹 배열, EnemySpawner (Empty obj)을 serializeField로 받아 생성 위치 및 EnemyLevel, Enemy 생성 주기를 다루기 위하여 EnemyGenerator를 따로 만들어 놓았음 Enemy뿐만 아니라 Boss몹은 예외처리를 통하여 구현함
**중력**을 이용하여 enemy의 속도를 결정하였는데 이 때 적들은 **무작위** 중력으로 게임을 진행함 

- GameManager
> 플레이어의 점수와 다양한 UI 관리, Scene 관리 및 Score에 따른 변화들을 관리 get & and 연산 가능

- LaserColl
> Script의 이름은 LaserColl이지만, 다양한 laser collision들을 이 한 곳에서 묶어서 사용하게 된다. 각 laser 프리팹마다 적용시켜준 script로서 LaserColl이라고 붙이게 됨

- LaserController
> 무기 레벨에 따라서 다양한 레이저를 사용할 수 있게 만든 script LaserGenerator 역할

- PlayerController
> Player가 밖으로 이동하지 못하게 ViewPort를 통하여 위치를 정립해주고(**플레이어의 이동**) 다양한 키입력을 받아 LaserController와의 연동 및 시간이 지날수록 플레이어의 이동속도를 올려 게임을 흥미진진하게 도와주고 여기서도 또한 충돌을 생각하였음

- SqaureCollider
> prefab을 destroy하는 방법을 고민하다가, 안보이는 Sqaure를 만들어놓고 이 Square에 충돌할 시에 laser가 삭제되게 구현함에 따라 필요한 script
