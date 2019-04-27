using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootSpeedLevel : MonoBehaviour
{
    private float nTimer = 0f;
    private bool isDone = false;

    public GameObject[] Bosses;
    public Transform BossStartPosition;
    private float nTimerBoss;
    private int nBossNumber = 0;

    //[HideInInspector]
    //public enum Boss { GetReady, Boss };
    //[HideInInspector]
    //public Boss BossState;


    void Update()
    {
        if (!isDone)
        {
            nTimer += Time.deltaTime;
            LevelDifficultyUp();
        }
        BossGo(nBossNumber);
    }

    private void BossGo(int numBoss)
    {
        if (Root.rootGame.GameState != Root.Game.Dead && nBossNumber < Bosses.Length)
        {
            nTimerBoss += Time.deltaTime;
            if (nTimerBoss >= 60f && nTimerBoss < 64)
            {
                Root.rootGame.isBossComming = true;
            }
            else if (nTimerBoss >= 65)
            {
                GameObject boss = Instantiate(Bosses[numBoss], BossStartPosition.position, Quaternion.identity) as GameObject;
                nBossNumber++;
                nTimerBoss = 0;
            }
        }
    }


    private void LevelDifficultyUp()
    {
        if (nTimer >= 30f)
        {
            if (PlayerPrefs.GetInt("lifePoints") <= 4)
            {
                int Enemylife = PlayerPrefs.GetInt("lifePoints") + 1; // lifePoints UP
                PlayerPrefs.SetInt("lifePoints", Enemylife);          // Seve
                Debug.Log("Enemylife" + Enemylife);
            }

            if (PlayerPrefs.GetFloat("speedEnemy") <= 5.5f)
            {
                float EnemySpeed = PlayerPrefs.GetFloat("speedEnemy") + 0.15f; //Speed UP
                PlayerPrefs.SetFloat("speedEnemy", EnemySpeed);               //Save
                Debug.Log("EnemySpeed" + EnemySpeed);
            }

            if (PlayerPrefs.GetFloat("shootDelay") > 1f)
            {
                float EnemyShoot = PlayerPrefs.GetFloat("shootDelay") - 0.05f; //Shoot Speed UP
                PlayerPrefs.SetFloat("shootDelay", EnemyShoot);               //Save
                Debug.Log("EnemyShoot" + EnemyShoot);
            }

            if (EnemyGenerator.enemyGenerator.maxDelay >= EnemyGenerator.enemyGenerator.minDelay)
            {
                EnemyGenerator.enemyGenerator.maxDelay -= 0.2f;
            }

            if (PlayerPrefs.GetInt("lifePoints") >= 4 && PlayerPrefs.GetFloat("speedEnemy") >= 5.5f && PlayerPrefs.GetFloat("shootDelay") <= 0.8f && EnemyGenerator.enemyGenerator.maxDelay <= EnemyGenerator.enemyGenerator.minDelay)
            {
                isDone = true;
                Debug.Log("Time Done!");
            }

            nTimer = 0;
        }
    }
}
