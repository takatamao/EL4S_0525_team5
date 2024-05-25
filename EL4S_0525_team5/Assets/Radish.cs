using DG.Tweening;
using UnityEngine;

public class Radish : GimmickBase
{
    private float currentCuttingTime = 0.0f;

    [SerializeField]
    private float requiredCutTime = 0.1f;

    private Sequence cutSequence;

    private SlashSpawner _spawner;

    protected override void OnStart()
    {
        _spawner = GameObject.FindWithTag("ES").GetComponent<SlashSpawner>();

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
        _spawner.GenerateSlashEffect();
        _spawner.GenerateZaku();

        Destroy(this.gameObject);
    }

    protected override void OnCutFailure()
    {
        _spawner.GenerateSuka();

        isCutFailed = true;
        Debug.Log("通過");
    }

    protected override void OnHitKnifeEnter(Collider2D collision)
    {
        //try
        //{
        //    Instantiate(_objectFragment);
        //}
        //catch
        //{
        //     Debug.LogError("破片オブジェクトがアタッチされていません！");
        //}

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
                        float distance = Mathf.Abs(transform.position.x);
                        float score = (1.0f - distance) * _baseScore;

                        SlashResult slashResult = new();
                        slashResult.SetScore(score);
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
