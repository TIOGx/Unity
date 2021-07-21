# [Unity] 테트리스 만들기
### 현 상태

<img src="https://user-images.githubusercontent.com/22341383/126471975-ba4c1003-b8f8-479f-8533-3d0275c7dc4a.gif" width="40%">

### 진행도
1. UI 구성
    1) ScoreBoard
        - 점수 표시 및 줄 파괴시 +1 점
    2) Timer
        - 남은 시간 표시 및 줄 파괴시 + 5초
3. background, Tetris Block object 생성
4. 기능구현  
    1) TetrisController
        - 키보드를 이용한 블럭 이동
        - A 키를 이용한 블럭회전
        - 블럭 자동 하강
        - 블럭 이동 가능 판정
        - 블럭 자동 하강 불가시 블럭쌓고 새로운 블럭 생성 및 스크립트 죽이기 TetrisCreator.CreatBlock()
        - 블럭 쌓기 및 각 row 상태 확인 및 삭제 후 row 밀기
        - S 키를 이용한 블럭 바로 내리기
    2) TetrisCreator
        - Prefab을 활용한 랜덤 블럭 자동 생성

