using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public  class Root : MonoBehaviour
{
    [HideInInspector]
    public static Root rootGame;
    [HideInInspector]
    public enum Game { Play, Dead };
    [HideInInspector]
    public Game GameState;

    private void Awake()
    {
        PlayerPrefs.SetInt("lifePoints", 2);
        PlayerPrefs.SetFloat("speedEnemy", 2f);
        PlayerPrefs.SetFloat("shootDelay", 2f);
    }

    // Start is called before the first frame update
    void Start()
    {

        rootGame = this;
        GameState = Game.Play;
    }
}
