using DG.Tweening;
using UnityEngine;

public class PurpleCabbage : GimmickBase
{
    [SerializeField]
    private float cuttingTime = 1.0f;

    [SerializeField]
    private float requiredCutCount = 3;

    private float currentCutCount = 0;

    protected override void OnStart()
    {
        Sequence sequence = DOTween.Sequence()
            .Append(
                transform.DOMove(CUT_POSITION, _duration)
                .SetEase(Ease.Linear)
                .SetRelative(true))
            .AppendInterval(cuttingTime)
            .AppendCallback(() => OnCutFailure())
            .SetLink(gameObject);
    }

    protected override void OnCutSuccess()
    {
        Destroy(this.gameObject);
    }

    protected override void OnCutFailure()
    {
        Sequence sequence = DOTween.Sequence()
            .Append(
                transform.DOMove(CUT_POSITION, _duration)
                .SetEase(Ease.Linear).
                SetRelative(true))
            .SetLink(gameObject);

        Debug.Log("カット失敗:通過");
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

        currentCutCount++;

        if (currentCutCount >= requiredCutCount)
        {
            var slashResultApplyable = collision.GetComponentInParent<ISlashResultApplyable>();
            if (slashResultApplyable != null)
            {
                SlashResult slashResult = new();
                slashResult.SetSuccessed(true);
                slashResultApplyable.ApplySlashResult(slashResult);
            }

            OnCutSuccess();
        }
    }
}
