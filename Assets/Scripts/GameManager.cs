using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemyObjs;
    public Transform[] spawnPoints;

    public float maxSpawnDelay;
    public float curSpawnDelay;

    void Update()
    {
        curSpawnDelay += Time.deltaTime;

        if(curSpawnDelay > maxSpawnDelay )
        {
            SpawnEnemy();
            maxSpawnDelay = Random.Range(0.5f, 3f);
            curSpawnDelay = 0;      // 적 생성 후엔 꼭 딜레이 변수 0으로 초기화
        }
    }

    // 랜덤으로 정해진 적 프리펩, 생성 위치로 적 기체 생성.
    void SpawnEnemy()
    {
        int ranEnemy = Random.Range(0, 3);
        int ranPoint = Random.Range(0, 5);

        Instantiate(enemyObjs[ranEnemy], 
            spawnPoints[ranPoint].position, 
            spawnPoints[ranPoint].rotation);



        
    }
}
