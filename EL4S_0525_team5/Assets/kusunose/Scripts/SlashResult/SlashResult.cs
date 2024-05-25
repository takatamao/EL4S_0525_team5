using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashResult
{
    /// <summary>
    /// �؂�̂ɐ���������
    /// </summary>
    private bool isSuccessed = false;
    public bool IsSuccessed => isSuccessed;

    /// <summary>
    /// �X�R�A
    /// </summary>
    private float score = 0;
    public float Score => score;

    /// <summary>
    /// �ڂ���܂�����
    /// </summary>
    private float blindDuration = 0.0f;
    public float BlindDuration => blindDuration;

    /// <summary>
    /// �������������Z�b�g
    /// </summary>
    /// <param name="successed"></param>
    public void SetSuccessed(bool successed)
    {
        isSuccessed = successed;
    }

    /// <summary>
    /// �X�R�A���Z�b�g
    /// </summary>
    /// <param name="value"></param>
    public void SetScore(float value)
    {
        score = value;
    }

    /// <summary>
    /// �ڂ���܂��̎��Ԃ��Z�b�g
    /// </summary>
    /// <param name="duration"></param>
    public void SetBlindDuration(float duration)
    {
        blindDuration = duration;
    }
}
