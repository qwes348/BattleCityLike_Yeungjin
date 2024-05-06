# 이 브랜치에서 구현된 내용

- `Enemy.cs`스크립트 수정
  - 공격 조건 코드 수정
  - `destination`을 플레이어가 아닌 맵의 빈 공간을 받아와서 설정
  - 현재 목적지 기즈모 Draw 코드 추가
- `MapManager.cs`스크립트 수정
  - 맵의 장애물이 없는 빈 좌표를 반환하는 함수 추가
- `EnemySpawner.cs` 스크립트 추가
  - `Enemy`프리팹을 일정 시간 간격으로 소환 함
- `GameManger.cs` 스크립트 추가
  - 지금은 `R`키 입력 시 레벨을 다시 시작하는 기능만 있음

## 그 밖에 씬에서 수정된 부분

- 적 탱크
  - `Nav Mesh Agent`컴포넌트
    - `Base Offset: 0.8`로 조정
    - `Stopping Distance: 1`로 조정
  - `Enemy`컴포넌트
    - `Cool_bullet: 2`로 조정
  - 컴포넌트들 프리팹에 추가/변경사항 적용
- `Manager`
  - `EnemySpawner`오브젝트 추가 및 `EnemySpawner`컴포넌트 부착
  - 설정 값:
    - `Spawn Dest Count : 5`
    - `Spawn Interval : 5`
    - `Go_enemy Prefab : TankFree_Blue`
