using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Test : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(ScoreTable.Instance.GetSocre().ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ScoreTable.Instance.ScoreIncrease(10);
        }

        if (CountDownCounter.Instance.GetReady())
        {
            SceneManager.LoadScene("Test");
        }
    }
}
