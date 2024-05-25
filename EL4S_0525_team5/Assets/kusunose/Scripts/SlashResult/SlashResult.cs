using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashResult
{
    /// <summary>
    /// 切るのに成功したか
    /// </summary>
    private bool isSuccessed = false;
    public bool IsSuccessed => isSuccessed;

    /// <summary>
    /// スコア
    /// </summary>
    private float score = 0;
    public float Score => score;

    /// <summary>
    /// 目くらまし時間
    /// </summary>
    private float blindDuration = 0.0f;
    public float BlindDuration => blindDuration;

    /// <summary>
    /// 成功したかをセット
    /// </summary>
    /// <param name="successed"></param>
    public void SetSuccessed(bool successed)
    {
        isSuccessed = successed;
    }

    /// <summary>
    /// スコアをセット
    /// </summary>
    /// <param name="value"></param>
    public void SetScore(float value)
    {
        score = value;
    }

    /// <summary>
    /// 目くらましの時間をセット
    /// </summary>
    /// <param name="duration"></param>
    public void SetBlindDuration(float duration)
    {
        blindDuration = duration;
    }
}
