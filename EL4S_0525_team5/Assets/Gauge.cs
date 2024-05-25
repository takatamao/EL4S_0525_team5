using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gauge : MonoBehaviour
{
    [SerializeField] private Image _front;

    [SerializeField] private float _coolTime;

    void Start()
    {
        //coolTime = TimeBody.timeBody._stopTime;
        _front.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        _front.fillAmount -= 1 / _coolTime * Time.deltaTime;
        if (_front.fillAmount <= 0) _front.fillAmount = 1;
    }
}
