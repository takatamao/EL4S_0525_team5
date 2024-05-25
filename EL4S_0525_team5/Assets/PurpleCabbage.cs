using DG.Tweening;
using UnityEngine;

public class PurpleCabbage : GimmickBase
{
    [SerializeField]
    private float cuttingTime = 1.0f;

    [SerializeField]
    private float requiredCutCount = 3;

    private float currentCutCount = 0;

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
            .AppendInterval(cuttingTime)
            .AppendCallback(() => OnCutFailure())
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
        Sequence sequence = DOTween.Sequence()
            .Append(
                transform.DOMove(CUTTING_VELOCITY, _duration)
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

        currentCutCount++;

        var slashResultApplyable = collision.GetComponentInParent<ISlashResultApplyable>();
        if (slashResultApplyable != null)
        {
            float distance = Mathf.Abs(transform.position.x);
            float score = (1.0f - distance) * _baseScore / requiredCutCount;

            SlashResult slashResult = new();
            slashResult.SetScore(score);
            slashResult.SetSuccessed(true);
            slashResultApplyable.ApplySlashResult(slashResult);
        }

        if (currentCutCount >= requiredCutCount)
        {
            OnCutSuccess();
        }
    }
}
