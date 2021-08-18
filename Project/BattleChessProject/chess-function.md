# BattleChessGame 함수 정리

### GameManager
- InitializeTile() : tile 설정 초기화 함수
- InitializeActive() : 체스 말들의 공격, 움직임을 막는 함수
- HighlightTile(GameObject GObject) : 갈 수 있는 타일 highlight
- BattlePhase() :  전투 페이즈 담당 함수
- NextTurn() : 턴 종료 페이즈 담당 함수
- GetPlayer() : player가 blackteam이면 true return
- SpawnEnemy() : 적 생성 함수
- SetBoard(GameObject GObject, int idxX, int idxY) : board set
- GetBoard(int idxX, int idxY) : board get
- SetTile(GameObject GObject, int idxX, int idxY) :  Tile set
- GetTile(int idxX, int idxY) : Tile get

### MoveManager
- MovablePieceHighlight(GameObject GObject) : 체스말의 타입을 확인하고 움직일 수 있는 칸을 highlight 해주는 함수
- CheckMyTurn(string str) : 자신의 턴인지 확인하는 함수

### BuildManager
- SetActiveFalseTime(GameObject gameObject, float WaitSeconds) : canvas gameObject를 WaitSeconds 만큼 흐른 뒤 사라지게 하는 코루틴 함수
- SetClassType(int Ict) : 각 class를 숫자로 upcast 해주는 함수
- InitializeSelectTile() : SelectTile을 null로 initialize 해주는 함수
- SetSelectTile(GameObject GObject) : set SelectTile
- GetSelectTile() : get SelectTile
- BuildWhitePiece(GameObject WhitePiece) : White piece를 build 해주는 함수
- BuildBlackPiece(GameObject BlackPiece) : Black piece를 build 해주는 함수
- SelectPiece() : ChoosePieceCanvas 를 띄워주는 함수
- SelectClass() : ChooseClassCanvas 를 띄워주는 함수

### UIManager
1. ChoosePieceCanvas
- ChooseCanvasFalse() : ChoosePieceCanvas 를 active(false) 해주는 함수
- ChooseCanvasTrue() : ChoosePieceCanvas 를 active(true) 해주는 함수
2. SelectPosCanvas
- SelectCanvasFalse() : SelectPosCanvas 를 active(false) 해주는 함수
- SelectCanvasTrue(): SelectPosCanvas 를 active(true) 해주는 함수
- GetSelectCanvas() : get SelectPosCanvas
3. ChooseClassCanvas
- ChooseClassCanvasFalse() : ChooseClassCanvas 를 active(false) 해주는 함수
- ChooseClassCanvasTrue(): ChooseClassCanvas를 active(true) 해주는 함수
4. teamcolorCanvas
- TextMeshProUGUI GeteamcolorCanvas() : get teamcolorCanvas

### CameraManager
- BlackTeamCameraOn() : black team 카메라로 이동하게 하는 함수
- WhiteTeamCameraOn() : white team 카메라로 이동하게 하는 함수

### PieceController
- SetMovable(bool BMove) : set movable
- GetMovable() : get movable
- DivideType() : Piecetype의 타입을 나누는 함수
- PieceType GetPiecetype() : get  Piecetype
- Damaged(float damage) : 공격을 받으면 작동, damagetext와 hp를 업데이트 해주는 함수.
- Attack() : 공격 함수
- Move(int x, int z, int originx, int originz) : move 함수
- Die() : 체스 말 die 함수

### ArrowController
> arrow prefab 관리

### Tile
- SetMovable(bool BMove)  : set movable
- GetMovable()  : get movable
- OnMouseUp() : 보드 타일을 눌러서 tile을 select 해주는 함수

### DamageText
> damagetext 관리
