using DG.Tweening;
using UnityEngine;

public class Radish : GimmickBase
{
    private float currentCuttingTime = 0.0f;

    [SerializeField]
    private float requiredCutTime = 0.1f;

    Sequence cutSequence;

    protected override void OnStart()
    {
        cutSequence = DOTween.Sequence()
            .Append(
                transform.DOMove(CUT_POSITION, _duration)
                .SetEase(Ease.Linear)
                .SetRelative(true))
            .AppendCallback(() => OnCutFailure())
            .SetLink(gameObject);
    }

    protected override void OnCutSuccess()
    {
        Destroy(this.gameObject);
    }

    protected override void OnCutFailure()
    {
        cutSequence = DOTween.Sequence()
            .Append(
                transform.DOMove(CUT_POSITION, _duration)
                .SetEase(Ease.Linear).
                SetRelative(true))
            .SetLink(gameObject);

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

        if(cuttingState == CuttingState.NotCut)
        {
            cuttingState = CuttingState.Cutting;
            cutSequence.Pause();
        }
    }

    protected override void OnHitKnifeStay(Collider2D collision)
    {
        switch (cuttingState)
        {
            case CuttingState.Cutting:
                currentCuttingTime += Time.deltaTime;
                if (currentCuttingTime >= requiredCutTime)
                {
                    cuttingState = CuttingState.CutComplete;

                    var slashResultApplyable = collision.GetComponentInParent<ISlashResultApplyable>();
                    if (slashResultApplyable != null)
                    {
                        SlashResult slashResult = new();
                        slashResult.SetSuccessed(true);
                        slashResultApplyable.ApplySlashResult(slashResult);
                    }

                    OnCutSuccess();
                }
                break;
        }
    }

    protected override void OnHitKnifeExit(Collider2D collision)
    {
        currentCuttingTime = 0;
        cutSequence.Play();
    }

}
