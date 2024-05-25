using DG.Tweening;
using UnityEngine;

public class Onion : GimmickBase
{
    private void Start()
    {
        Sequence sequence = DOTween.Sequence();
        sequence
            .Append(
                transform.DOMoveX(-10, 2.0f)
                .SetEase(Ease.Linear)
                .SetRelative(true))
            .Append(
                transform.DOMoveX(-10, 2.0f)
                .SetEase(Ease.Linear).
                SetRelative(true))
            .SetLink(gameObject);
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
            SlashResult slashResult = new();
            slashResult.SetSuccessed(false);
            slashResultApplyable.ApplySlashResult(slashResult);
        }

        Destroy(this.gameObject);
    }
}
