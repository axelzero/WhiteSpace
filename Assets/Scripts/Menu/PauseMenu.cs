using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public bool Pause = false;
    public bool Sound = false;
    public Color[] soundColor;
    public Text soundBtn;

    public GameObject PausePanel;
    private void Start()
    {
        if (AudioListener.volume == 0)
        {
            soundBtn.color = soundColor[1];
            Sound = false;
        }
        else
        {
            soundBtn.color = soundColor[0];
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
            return;
        }
        if (!Pause)
        {
            PausePanel.SetActive(true);
            Time.timeScale = 0.0001f;
            Pause = true;
            return;
        }
    }

    public void MainMenuBtn()
    {
        Time.timeScale = 1;
        Application.LoadLevel("MainMenu");
    }

    public void SoundBtn()
    {
        if (Sound)
        {
            AudioListener.volume = 0;
            soundBtn.color = soundColor[1];
            Sound = false;
            return;
        }

        if (!Sound)
        {
            AudioListener.volume = 1;
            soundBtn.color = soundColor[0];
            Sound = true;
            return;
        }
    }

    public void ExitBtn()
    {
        Application.Quit();
    }
}
