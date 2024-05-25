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
    /// �ڂ���܂��̎��Ԃ��Z�b�g
    /// </summary>
    /// <param name="duration"></param>
    public void SetBlindDuration(float duration)
    {
        blindDuration = duration;
    }
}
