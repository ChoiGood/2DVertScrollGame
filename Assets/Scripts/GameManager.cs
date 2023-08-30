using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string[] enemyObjs;
    public Transform[] spawnPoints;

    public float maxSpawnDelay;
    public float curSpawnDelay;

    public GameObject player;
    public Text scoreText;
    public Image[] lifeImage;
    public Image[] boomImage;
    public GameObject gameOverSet;
    public ObjectManager objectManager;

    void Awake()
    {
        enemyObjs = new string[] { "EnemyL", "EnemyM", "EnemyS" };
    }

    void Update()
    {
        curSpawnDelay += Time.deltaTime;

        if(curSpawnDelay > maxSpawnDelay )
        {
            SpawnEnemy();
            maxSpawnDelay = Random.Range(0.5f, 3f);
            curSpawnDelay = 0;      // �� ���� �Ŀ� �� ������ ���� 0���� �ʱ�ȭ
        }

        // #. UI Score Update
        Player playerLogic = player.GetComponent<Player>();
        scoreText.text = string.Format("{0:n0}", playerLogic.score);
    }

    // �������� ������ �� ������, ���� ��ġ�� �� ��ü ����.
    void SpawnEnemy()
    {
        int ranEnemy = Random.Range(0, 3);
        int ranPoint = Random.Range(0, 9);

        GameObject enemy = objectManager.MakeObj(enemyObjs[ranEnemy]);
        enemy.transform.position = spawnPoints[ranPoint].position;

        Rigidbody2D rigid = enemy.GetComponent<Rigidbody2D>();
        Enemy enemyLogic = enemy.GetComponent<Enemy>();
        enemyLogic.player = player;     // �������� �̹� Scene�� �ö�� ������Ʈ�� ���� �Ұ���!! �׷��� Enemy���� �ٷ� player�� ���޴´�  
                                        // ==> �� ���� ���� �÷��̾� ������ �Ѱ��ִ� ������ �ذᰡ���ϴ�!!

        enemyLogic.objectManager = objectManager;
        if (ranPoint == 5 || ranPoint == 6) // #.Right Spawn
        {
            enemy.transform.Rotate(Vector3.back * 45);
            rigid.velocity = new Vector2(enemyLogic.speed * (-1), -1);
        }
        else if (ranPoint == 7 || ranPoint == 8)    // #.Left Spawn
        {
            enemy.transform.Rotate(Vector3.forward * 45);
            rigid.velocity = new Vector2(enemyLogic.speed, -1);
        }
        else    //#. Frong Spawn
        {
            rigid.velocity = new Vector2(0, enemyLogic.speed * (-1));
        }
    }
    public void UpdateLifeIcon(int life)
    {
        // Image�� �ϴ� ��� ���� ���·� �ΰ�, ������ ������ ����.

        // #.UI Life Init Disable
        for (int i=0; i<3; i++)
        {
            lifeImage[i].color = new Color(1, 1, 1, 0);
        }

        // #.UI Life Active
        for(int i=0; i<life; i++)
        {
            lifeImage[i].color = new Color(1, 1, 1, 1);
        }
    }

    public void UpdateBoomIcon(int boom)
    {
        // Image�� �ϴ� ��� ���� ���·� �ΰ�, ������ ������ ����.

        // #.UI Boom Init Disable
        for (int i = 0; i < 3; i++)
        {
            boomImage[i].color = new Color(1, 1, 1, 0);
        }

        // #.UI Boom Active
        for (int i = 0; i < boom; i++)
        {
            boomImage[i].color = new Color(1, 1, 1, 1);
        }
    }
    public void RespawnPlayer()
    {
        Invoke("RespawnPlayerExe", 2f);    // �÷��̾� ���ʹ� �ð� ���� �α� ���� Invoke() ���
    }

    void RespawnPlayerExe()
    {
        player.transform.position = Vector3.down * 3.5f;
        player.SetActive(true);

        Player playerLogic = player.GetComponent<Player>();
        playerLogic.isHit = false;
    }

    public void GameOver()
    {
        gameOverSet.SetActive(true);
    }

    public void GameRetry()
    {
        SceneManager.LoadScene(0);
    }

}
