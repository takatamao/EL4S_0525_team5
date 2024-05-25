using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneManager : MonoBehaviour
{

    public void OnTitleButton()
    {
        SceneManager.LoadScene("Title");
    }
    public void OnGameButton()
    {
        SceneManager.LoadScene("InGame");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGame();
        }
        if(Input.GetKeyDown(KeyCode.Return))
        {
            string sceneName = SceneManager.GetActiveScene().name;
            if (sceneName == "Title")
            {
                SceneManager.LoadScene("InGame");
            }
            else if (sceneName == "Result")
            {
                SceneManager.LoadScene("Title");
            }
            else { }
        }
    }

    public void ExitGameButton()
    {
        ExitGame();
    }

    private void ExitGame()
    {
        // エディタでの動作確認用
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // ビルドされたゲームでの終了処理
        Application.Quit();
#endif
    }
}
