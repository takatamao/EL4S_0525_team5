using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountDownCounter : MonoBehaviour
{
    public static CountDownCounter Instance;

    private TextMeshProUGUI text;
    public int countDownTime;

    private float nextTime = 1;
    private int time;

    private bool ready = false;

    private void Awake()
    {
        Instance = this;
        text = GetComponentInChildren<TextMeshProUGUI>();
        ready = false;
        time = countDownTime;
        text.text = string.Format("{0:d2}:{1:d2}", time / 60, time % 60);
    }

    private void OnEnable()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        ready = false;
        time = countDownTime;
        text.text = string.Format("{0:d2}:{1:d2}", time / 60, time % 60);
    }
    // Update is called once per frame
    void Update()
    {
        Timer1();
    }

    private void Timer1()
    {

        if (time > 0)
        {
            if (time <= 5)
            {
                text.color = Color.red;
            }

            if (Time.time >= nextTime)
            {
                time--;
                text.text = string.Format("{0:d2}:{1:d2}", time / 60, time % 60);

                nextTime = Time.time + 1;
            }
        }
        else if (time <= 0)
        {
            ready = true;
            time = countDownTime;
            gameObject.SetActive(false);

        }
    }

    public bool GetReady()
    {
        return ready;
    }


}
