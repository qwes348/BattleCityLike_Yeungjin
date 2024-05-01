# 전 회차 강의 과제

- 적 캐릭터가 미사일 발사
- 적 미사일에 적중되면 게임 오버
- 맵 2개 이상 만들어서 불러오기

# 이 브랜치에서 구현된 내용

- 태그 3종 추가 `player`, `enemy`, `enemy_bullet`

### `Enemy.cs`

- 투사체 발사 기능 추가
- `InputManger.cs`의 플레이어 투사체 발사 기능 그대로 인용
- 데미지를 받을 때 호출될 함수인 `TakeDamage()`함수 추가
  - 지금은 데미지를 받으면 `Destroy()`실행만 함

### `Bullet.cs`

- 적에게 충돌했을 시 투사체가 Destroy되는 부분 추가 `(line 25)`
- 적의 `TakeDamage()`함수 호출하는 부분 추가

### `MapManager.cs`

- 맵 배열 한개 더 추가 `(map_01)`
- `Update`문에서 숫자 키 입력을 감지해서 맵 교체하는 코드 추가
  - 추후에는 UI상에서 맵을 선택하는걸로 구현 예정

### `EnemyBullet.cs`

- 추가된 스크립트
  - Enemy탱크와 플레이어 탱크의 태그를 다르게 설정하고 충돌 감지를 위함
- 내용은 `Bullet.cs`와 거의 같음
- 태그 비교에서 태그 이름만 변경

### `PlayerTank.cs`

- 추가된 스크립트
  - 플레이어 탱크의 피격 처리를 위함
- 피격 시 플레이어 탱크 오브젝트를 비활성화 하고 `Debug.Log("Game Over !!");`를 출력 함

### 그 밖에 씬에서 수정된 부분

- 적 탱크
  - 투사체 발사를 위해 발사 포지션 오브젝트`(go_silo)`를 추가
  - `Nav Mesh Agent`컴포넌트의 `StoppingDistance`값 수정

### 여담

- `StageData.cs`, `StageDataEditor.cs`는 레벨 에디터 GUI를 구현해보기 위한 목적으로 생성 함
  - 구현은 덜 된 상태
- 하지만 학생들 입장에서 로직이 복잡 해 질것같아 일단 보류
