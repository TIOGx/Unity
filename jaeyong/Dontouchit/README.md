# Dontouchit (Don't Touch It)

## Tilemap

2D에서 Tilemap을 이용하여 바닥을 생성하였다. Tile Size와 Grid size가 다를 때에는 Sprite Image Inspector에서 Pixels per unit을 픽셀에 맞게 변경시켜주면 사이즈가 올바르게 변경된다.
Tile Palette에서 Scene으로 Brush함으로 한 칸 한 칸 만들 수 있고, [Tilemap Collider](#Tilemap Collider)가 존재하여 이 Component를 추가함으로 충돌을 확인할 수 있게 만들었다.

### Tilemap Collider
used by composite property를 이용하여 모든 타일에 대해서 하나로 합쳐 Collider가 되게 만들었다. used by composite을 사용하고 **Composite Collider 2D 컴포넌트도 추가시켜줘야 한다.**

### Rigidbody2D

움직이지 않는 바닥이므로 Rigidbody2D를 static으로 설정한다.

## Player

Image가 하나에 여러 상태가 겹쳐져 있다면, Sprite Editor를 이용하여 Image를 slice할 수 있는데 슬라이스를 진행하게 되면 와 같은 상태로 변경되고, 전부 끌어다가 Hierarchy창으로 움직이면 animation 저장을 통하여 플레이어를 생성할 수 있다.
캐릭터 또한 Collider와 Rigidbody 설정하여야 한다.

### Controller

캐릭터의 이동 먼저 생각해보자. 예전에는 If(Input.GetKeyDown(key));을 사용하여 버튼이 눌린것을 확인하였지만 이번에는 Input.GetAxis("Horizontal"); 을 사용했다.
Axis 등 다양한 Input에 대한 값을 확인하기 위하여는 Project Settings에서 InputManager를 확인하면 된다. DebugLog로 확인해 본 결과 -1부터 1까지의 값으로 float horizontal이 나타났다.

### Animator

기존에 사용했던 애니메이터처럼 Player Controller에서 animator component를 설정해주고, animator에서 만들었던 parameter를 변경시켜주기 위하여 animator.SetFloat("speed",Mathf.Abs(horizontal))을 사용합니다.

### LocalScale? Flip?

전에 플레이어를 뒤집기 위하여 LocalScale 값을 바꿔주면서 실행했었음. 유니티 교과서 327p에 자세히 나와있는데, 이것과 다르게 이번에는 Sprite Renderer에 있는 flip을 사용해보겠다.
Sprite Renderer를 Component로 얻어와서 renderer.flipX = true와 false를 통해서 진행하면 되고, 애니메이션도 따라서 바뀐다.

### Exception case

예전 ClimbCat을 구현할 때에는 화면 밖으로 나갔는지 하드코딩을 통하여 transform.position.y를 직접 구하여 값보다 작은지 조건을 두어 처음부터 실행하게 진행하였는데, 이번에는 Camera.main.WorldToViewportPoint를 사용했다. 뷰포트 좌표계는 화면에 글자나 2D 이미지를 표시하기 위한 좌표계인데, 화면의 왼쪽 아래를 (0,0) 오른쪽 위를 (1,1)로 하는 평면 상대 좌표계이다.
스크린좌표에서는 해상도에 따라서 카메라의 위치나 각도와 상관없이 일정하다.
ViewportToWorldPoint를 이용하여 다시 뷰포트에서 WolrdPoint로 WorlPos를 주어 정해진 x좌표 이하나 이상으로 움직이지 못하게 처리를 도와주었다. (ScreenCheck() 메소드)

## Prefab

### Create

Instantiate(object, 좌표, 쿼터니언)으로 오브젝트를 생성한다.
Quaternion.Identity를 이용하여 오브젝트는 회전을 하지 못하게 만듦.
**Coroutine**을 사용하여 오브젝트를 생성하게 만들었는데, 코루틴에 대해서는 추후 Issue로 다루어 Review하는 시간을 가져보겠음.

### 유의사항

씬에는 분명 프리팹이 잘 생성되지만 게임화면에서는 생성되지 않음? => Camera의 z 좌표보다 앞쪽에 있어야 게임 화면에 표시가 된다.

### StateMachineBehaviour

유니티 5부터 사용가능한 기능으로 애니메이터 상태에 따라 자동 호출이 된다.
animator에서 빈 state를 만들어서 behaviour(행동)을 추가시킬 수 있는데 애니메이터에서 내 오브젝트를 Destroy시킬 수 있다. 진행 동작은 애니메이터에서 Idle 상태로 시작하여 ground 태그에 닿으면 trigger가 발생한다. (SetTrigger) 이 후 poop 상태로 애니메이터가 동작하고, poop상태가 끝나게 되면 (OnStateExit) Destroy를 진행한다.

### 싱글톤 패턴

최초 한번만 메모리에 할당하고 인스턴스를 만들어 사용하는 패턴. 싱글톤을 사용하면 다른 오브젝트에서 매니저로의 접근이 쉬워지고 한개만 존재해도 되는 매니저의 특성을 살릴 수 있다.