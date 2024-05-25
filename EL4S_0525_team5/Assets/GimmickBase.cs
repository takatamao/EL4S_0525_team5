using UnityEngine;

public class GimmickBase : MonoBehaviour
{
    protected enum CuttingState
    {
        NotCut,
        Cutting,
        CutComplete,
    }

    protected static readonly Vector2 CUT_POSITION = new Vector2(-10, 0);
    [SerializeField] protected float _duration = 2.0f;
    [SerializeField] protected GameObject _objectFragment;

    protected CuttingState cuttingState = CuttingState.NotCut;

    private void Start()
    {
        OnStart();
    }

    private void Update()
    {
        OnUpdate();
    }

    /// <summary>
    /// カット成功時
    /// </summary>
    protected virtual void OnCutSuccess() { }

    /// <summary>
    /// カット失敗時
    /// </summary>
    protected virtual void OnCutFailure() { }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Knife")) OnHitKnifeEnter(collision);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Knife")) OnHitKnifeStay(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Knife")) OnHitKnifeExit(collision);
    }

    protected virtual void OnHitKnifeEnter(Collider2D collision) { }
    protected virtual void OnHitKnifeStay(Collider2D collision) { }
    protected virtual void OnHitKnifeExit(Collider2D collision) { }

    protected virtual void OnStart() { }
    protected virtual void OnUpdate() { }
}
