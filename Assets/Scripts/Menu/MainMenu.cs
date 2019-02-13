 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public int priceCoin = 200;
    public int hs;
    public int coins;
    public int shipNum;
    public Image[] Selector;
    public Color[] colors;
    public GameObject priceInCoins;
    public GameObject priceInDollars;

    public string[] PlayBtnText;
    public Text PlayBtnT;
    public Color[] playBtnColors;
    public Text txtCoins;
    public Text txtHs;
    public bool[] shipUnlock;

    public GameObject[] gamePanels;

    public bool sound;
    public Color[] soundColor;
    public Text soundBtn;

    public Sprite[] ships;

    void Start ()
    {
        Time.timeScale = 1;
        if (AudioListener.volume == 0)
        {
            soundBtn.color = soundColor[1];
            sound = false;
        }
        else
        {
            soundBtn.color = soundColor[0];
            sound = true;
        }

        hs = PlayerPrefs.GetInt("HS",0);
        coins = PlayerPrefs.GetInt("coins",0);
        if (PlayerPrefs.GetInt("Ship2") == 1)
        {
            shipUnlock[1] = true;
        }
        else
        {
            shipUnlock[1] = false;
        }
        ChangeShip(0);
	}
	
	void Update ()
    {
        txtCoins.text = coins.ToString();
        txtHs.text = "HIGHT SCORE: " + hs.ToString();
	}

    public void ChangeShip(int num)
    {
        switch (num)
        {
            case 0:
                Selector[0].color = colors[0];
                Selector[1].color = colors[1];
                Selector[2].color = colors[1];
                shipNum = 0;
                PlayBtnT.text = PlayBtnText[0];
                PlayBtnT.color = playBtnColors[0];
                priceInCoins.SetActive(false);
                break;
            case 1:
                Selector[0].color = colors[1];
                Selector[2].color = colors[1];
                shipNum = 1;
                if (shipUnlock[1] == false)
                {
                    Selector[1].color = colors[2];
                    priceInCoins.SetActive(true);
                    PlayBtnT.text = PlayBtnText[1];
                    PlayBtnT.color = playBtnColors[1];
                }
                else
                {
                    Selector[1].color = colors[0];
                    priceInCoins.SetActive(false);
                    PlayBtnT.text = PlayBtnText[0];
                    PlayBtnT.color = playBtnColors[0];
                }
                break;
            case 2:
                Selector[0].color = colors[1];
                Selector[1].color = colors[1];
                Selector[2].color = colors[0];
                shipNum = 2;
                PlayBtnT.text = PlayBtnText[1];
                PlayBtnT.color = playBtnColors[1];
                break;
        }
    }

    public void PlayBtn()
    {
        if (shipNum == 0)
        {
            SceneManager.LoadScene("1");
        }
        else if (shipNum == 1)
        {
            if (shipUnlock[1] == false)
            {
                if (coins >= priceCoin)
                {
                    coins -= priceCoin;
                    shipUnlock[1] = true;
                    PlayerPrefs.SetInt("Ship2", 1);
                    ChangeShip(1);
                }
            }
            else
            {
                SceneManager.LoadScene("1");
            }
        }
        PlayerPrefs.SetInt("ship", shipNum);
    }

    public void BtnHungar()
    {
        gamePanels[0].SetActive(false);
        gamePanels[1].SetActive(true);
    }

    public void BtnBackHungar()
    {
        gamePanels[0].SetActive(true);
        gamePanels[1].SetActive(false);
    }

    public void SoundBtn()
    {
        if (sound)
        {
            AudioListener.volume = 0;
            soundBtn.color = soundColor[1];
            sound = false;
            return;
        }

        if (!sound)
        {
            AudioListener.volume = 1;
            soundBtn.color = soundColor[0];
            sound = true;
            return;
        }
    }

    public void BtnExit()
    {
        Application.Quit();
    }
}
