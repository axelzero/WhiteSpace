using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public static class AchivsCommands 
{
    public static void GetTheAchiv(string id)
    {
        Social.ReportProgress(id, 100.0f, (bool success) =>
        {
            if (success) Debug.Log("Достижение " + id);
        });
    }
}
