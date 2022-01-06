using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
    using UnityEditor;
#endif
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text inputTxt;
    public Text highScoreTxt;

    private void Start()
    {
        GameManager.instance.ShowHighScore(highScoreTxt);
    }

    public void GameStart()
    {
        SceneManager.LoadScene(1);
    }

    public void SetPlayerName()
    {
        GameManager.instance.playername = inputTxt.text;
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
