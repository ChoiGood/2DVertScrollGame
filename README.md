# 2DVertScrollGame
[골드메탈] 2D 종스크롤 슈팅게임

구글링으로 게임개발자가 되기 위해서는 무엇을 공부해야하나요? 라는 질문에 추천 강의로 나오던

[골드메탈] 님의 유튜브 무료 강의를 보며 2D 종스크롤 슈팅게임의 기초에 대해 학습했습니다. 

--------------------------------
## 학습 내용
- 플레이어 이동
- 총알 발사 구현
  - 총알 프리펩
  - Instantiate(), Destroy()   
- 적 비행기 구현하기
  - 적 프리펩 
  - 적 기체 생성을 위한 GameManager 
- 적 전투와 피격 이벤트 만들기
- UI 간단하게 구현하기
- 아이템과 필살기 구현하기
- 원근감있는 무한 배경 만들기
  - 스크롤링
  - 패럴랙스
- 최적화의 기본, **오브젝트 풀링**
  - 오브젝트 풀링 : 미리 생성해둔 풀에서 활성화/비활성화로 사용
  - 왜? 이 기법을 사용하냐? Instantiate(), destroy() 하면서 조각난 메로리가 쌓임 ==> 가비지 컬렉터(GC)는 쌓인 조각난 메모리를 비워준다. BUT 실행될 때 게임이 살짝 끊기게 된다
  - 따라서 퀄리티있는 게임을 만들기 위해서는 **오브젝트 풀링** 기술은 필수이다!!
- 텍스트 파일을 이요한 커스텀 배치 구현
    - Resources : 런타임에서 불러오는 에셋이 저장된 폴더
    - 파일을 읽기 위한 System.IO 사용
- 따라다니는 보조무기 만들기
- 탄막을 뿜어내는 보스 만들기
  - 패턴 흐름, 패턴 구현
- 모바일 슈팅게임 만들기
-----------------------------------------------------
## 실행 화면







------------------------------------------

## 학습 영상 출처
<https://www.youtube.com/@goldmetal>
