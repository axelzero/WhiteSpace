using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public bool Pause = false;
    public bool Sound = false;
    public Color[] soundColor;
    public Text soundBtn;

    public GameObject PausePanel;

    [Space(20)]
    [Header("UI")]
    public GameObject pauseUI;
    public Sprite[] spritesSoundOnOff;
    public Image imgSound;

    private void Start()
    {
        if (AudioListener.volume == 0)
        {
            imgSound.sprite = spritesSoundOnOff[0];
            Sound = false;
        }
        else
        {
            imgSound.sprite = spritesSoundOnOff[1];
            Sound = true;
        }
    }

    public void PauseM()
    {
        if (Pause)
        {
            PausePanel.SetActive(false);
            Time.timeScale = 1;
            Pause = false;
            pauseUI.SetActive(true);
            return;
        }
        if (!Pause)
        {
            PausePanel.SetActive(true);
            Time.timeScale = 0.0001f;
            Pause = true;
            pauseUI.SetActive(false);
            return;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenuBtn()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void SoundBtn()
    {
        if (Sound)
        {
            AudioListener.volume = 0;
            Sound = false;
            imgSound.sprite = spritesSoundOnOff[0];
            return;
        }

        if (!Sound)
        {
            AudioListener.volume = 1;
            Sound = true;
            imgSound.sprite = spritesSoundOnOff[1];
            return;
        }
    }

    public void ExitBtn()
    {
        Application.Quit();
    }
}
