using DG.Tweening;
using UnityEngine;

public class Carrot : GimmickBase
{
    private Sequence cutSequence;

    protected override void OnStart()
    {
        cutSequence = DOTween.Sequence()
            .Append(
                transform.DOMove(BEFOR_CUT_VELOCITY, _duration)
                .SetEase(Ease.Linear)
                .SetRelative(true))
            .Append(
                transform.DOMove(CUTTING_VELOCITY, _duration)
                .SetEase(Ease.Linear)
                .SetRelative(true))
            .SetLink(gameObject);
    }

    protected override void OnUpdate()
    {
        if (false == isCutFailed && transform.position.x < -1)
        {
            OnCutFailure();
        }
    }

    protected override void OnCutSuccess()
    {
        Destroy(this.gameObject);
    }

    protected override void OnCutFailure()
    {
        isCutFailed = true;
        Debug.Log("通過");
    }

    protected override void OnHitKnifeEnter(Collider2D collision)
    {
        try
        {
            Instantiate(_objectFragment);
        }
        catch
        {
             Debug.LogError("破片オブジェクトがアタッチされていません！");
        }

        var slashResultApplyable = collision.GetComponentInParent<ISlashResultApplyable>();
        if(slashResultApplyable != null)
        {
            float distance = Mathf.Abs(transform.position.x);
            float score = (1.0f - distance) * _baseScore;

            SlashResult slashResult = new();
            slashResult.SetScore(score);
            slashResult.SetSuccessed(true);
            slashResultApplyable.ApplySlashResult(slashResult);
        }

        OnCutSuccess();
    }
}
