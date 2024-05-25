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
        
        // �G�f�B�^�ł̓���m�F�p
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        // �r���h���ꂽ�Q�[���ł̏I������
        Application.Quit();
#endif
        
    }
}
