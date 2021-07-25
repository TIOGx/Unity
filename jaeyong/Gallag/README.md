# Gallag 개별 프로젝트

## 만드는 중 ISSUE
Coroutine은 Player의 총알에 적이 맞았을 때 적이 점차 사라지는것을 Coroutine을 이용할 생각(공식문서에 나와있는 fadeout과 비슷하게)  

Singleton 패턴은 GameManager에게 적용시킬 것

## 현재까지의 Script

- EnemyGenerator
> 적을 생성하는 script파일으로 Enemy 프리팹 배열, EnemySpawner (Empty obj)을 serializeField로 받아 생성 위치 및 EnemyLevel, Enemy 생성 주기를 다루기 위하여 EnemyGenerator를 따로 만들어 놓았음
추후 GameManager로 enemylevel을 옮겨야 할지에 대한 판단이 필요

- GameManager
> 플레이어의 점수와 다양한 UI들 제공 

- LaserController
> Player가 사용하거나, 적이 사용하는 Laser를 컨트롤하는 것. enemy가 주체가 되면 laser의 velocity 값을 변경해주고 주체에 따라 변경되는 것을 control하기 위함의 script

- PlayerController
> Player가 밖으로 이동하지 못하게 ViewPort를 통하여 위치를 정립해주고, 다양한 키입력을 받는 주요한 script

- SqaureCollider
> 임시적으로 prefab을 destroy하는 방법을 고민하다가, 안보이는 Sqaure를 만들어놓고 이 Square에 충돌할 시에 laser가 삭제되게 구현함에 따라 필요한 script
