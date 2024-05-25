using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreTable : MonoBehaviour
{
    public static ScoreTable Instance;

    TextMeshProUGUI scoreText;
    static int score=0;

    void Awake()
    {
        ScoreTable.Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

        scoreText = GetComponent<TextMeshProUGUI>();
        if(scoreText != null )
        scoreText.text = string.Format("{0:d5}",score);
    }

    public void SetScore(int i)
    {
        score = i;
        scoreText.text = string.Format("{0:d5}", score);
    }
    public void ScoreIncrease(int i)
    {
        score += i;
        scoreText.text = string.Format("{0:d5}", score);
    }
    public void Reset()
    {
        score = 0;
    }

    public int GetSocre()
    {
        return score;
    }



    // Update is called once per frame
    void Update()
    {
        
       
    }
}
