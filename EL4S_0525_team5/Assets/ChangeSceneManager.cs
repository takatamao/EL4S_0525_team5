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

    public void ExitGameButton()
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
