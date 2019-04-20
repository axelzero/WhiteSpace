using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void LoadLevel()
    {
        SceneManager.LoadScene("Level");
    }
    public void LoadSpeedLevel()
    {
        SceneManager.LoadScene("SpeedLevel");
    }
}
