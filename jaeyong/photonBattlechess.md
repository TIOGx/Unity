# Photon

## PUN - Photon Unity Networking

### RPC란?

Remote Procedure Call로, 원격 프로시저 호출? 이해가 잘 안된다. 프로시저를 함수로 바꿔 생각해보면 조금 더 쉽게 느껴진다.
원격 함수 호출. 게임에 적용하게 되면 같은 룸에 있는 클라이언트의 함수를 실행하는 것이다.

예시로 보면 조금 더 쉽게 이해할 수 있다. 호스트(Player 1)와 클라이언트(Player 2)가 존재한다고 가정했을 때,
호스트의 화면에서는 이동을 하기 위해 flipX를 이용해서 스프라이트 렌더러에서 flipX가 일어났다고 하면
클라이언트(Player 2)의 화면에서는 이를 반영시켜주어야 하는데, Player 1의 함수를 불러와야 flipX가 일어나는 것은 누구나 이해할 수 있을것이다.
네트워크를 통해 다른 플레이어의 스크립트에서 해당 함수를 호출하려면 이 때 RPC가 필요한 것이다.

따라서, 우리 배틀 체스 게임에 적용해보았을때 정은지님이 정리해놓은 함수를 보고 판단해보았다.

GameManager 내에서의 함수들 중 RPC가 필요한 것이 무엇일까?

chess-function.md 일부
# BattleChessGame 함수 정리

### GameManager
- ~~InitializeTile() : tile 설정 초기화 함수~~
- ~~InitializeActive() : 체스 말들의 공격, 움직임을 막는 함수~~ // 자신의 기물만 판단할 수 있게 코드 수정 필요
- ~~HighlightTile(GameObject GObject) : 갈 수 있는 타일 highlight~~
- ~~BattlePhase() :  전투 페이즈 담당 함수~~
- **NextTurn() : 턴 종료 페이즈 담당 함수**
- ~~GetPlayer() : player가 blackteam이면 true return~~
- ~~SpawnEnemy() : 적 생성 함수~~ // 멀티가 되면서 제거되어야 할 함수

### MoveManager
- ~~MovablePieceHighlight(GameObject GObject) : 체스말의 타입을 확인하고 움직일 수 있는 칸을 highlight 해주는 함수~~
- ~~CheckMyTurn(string str) : 자신의 턴인지 확인하는 함수~~

### BuildManager
- ~~SetActiveFalseTime(GameObject gameObject, float WaitSeconds) : canvas gameObject를 WaitSeconds 만큼 흐른 뒤 사라지게 하는 코루틴 함수~~
- ~~SetClassType(int Ict) : 각 class를 숫자로 upcast 해주는 함수~~
- ~~InitializeSelectTile() : SelectTile을 null로 initialize 해주는 함수~~
- **BuildWhitePiece(GameObject WhitePiece) : White piece를 build 해주는 함수**
- **BuildBlackPiece(GameObject BlackPiece) : Black piece를 build 해주는 함수**
- ~~SelectPiece() : ChoosePieceCanvas 를 띄워주는 함수~~
- ~~SelectClass() : ChooseClassCanvas 를 띄워주는 함수~~

### UIManager
RPC가 필요 없다고 생각되어 그대로 사용하여도 될 듯

### CameraManager
위와 동일

### PieceController
- **Damaged(float damage) : 공격을 받으면 작동, damagetext와 hp를 업데이트 해주는 함수**
- **Attack() : 공격 함수**
- **Move(int x, int z, int originx, int originz) : move 함수**
- **Die() : 체스 말 die 함수**

### ArrowController
> arrow prefab 관리

### Tile


### DamageText
> damagetext 관리
