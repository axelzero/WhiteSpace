using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public  class Root : MonoBehaviour
{
    [HideInInspector]
    public static Root rootGame;
    [HideInInspector]
    public enum Game { Play, Dead, Pause };
    [HideInInspector]
    public Game GameState;

    [Space (20)]
    [Header ("Boss")]
    public bool isBossComming = false;
    public GameObject bossMessage;
    [HideInInspector]
    public float timerMessage = 0f;



    private void Awake()
    {
        PlayerPrefs.SetInt("lifePoints", 2);
        PlayerPrefs.SetFloat("speedEnemy", 2f);
        PlayerPrefs.SetFloat("shootDelay", 3f);
        rootGame = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameState = Game.Play;
    }

    private void Update()
    {
        if (isBossComming)
        {
            timerMessage += Time.deltaTime;
            bossMessage.SetActive(true);

            if (timerMessage >= 3f)
            {
                isBossComming = false;
                bossMessage.SetActive(false);
                timerMessage = 0;
            }
        }

        if (PlayerPrefs.GetInt("EnemyKilled") == 10)
        {
            AchivsCommands.GetTheAchiv(GPGSIds.achievement_kill_10_enemys);
        }

        if (PlayerPrefs.GetInt("EnemyKilled") == 50)
        {
            AchivsCommands.GetTheAchiv(GPGSIds.achievement_kill_50_enemys);
        }

        if (PlayerPrefs.GetInt("EnemyKilled") == 100)
        {
            AchivsCommands.GetTheAchiv(GPGSIds.achievement_kill_100_enemys);
        }
    }
}
