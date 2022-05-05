using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    public Text BestScoreText;

    private void Awake()
    {
        if (PlayerManager.Instance.bestScore == 0)
        {
            BestScoreText.text = "The best score is missing";
        }
        else
        {
            BestScoreText.text = $"{PlayerManager.Instance.bestPlayerName} has best score: {PlayerManager.Instance.bestScore}";
        }
       
    }
    public void SetName(string name)
    {
        PlayerManager.Instance.playerName = name;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        PlayerManager.Instance.SaveBestResult();
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit(); // original code to quit Unity player
        #endif
    }
}
