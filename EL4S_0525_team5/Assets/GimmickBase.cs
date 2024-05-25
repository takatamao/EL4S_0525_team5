using UnityEngine;

public class GimmickBase : MonoBehaviour
{
    protected static readonly Vector2 CUT_POSITION = new Vector2(-10, 0);
    [SerializeField] protected float _duration = 2.0f;
    [SerializeField] protected GameObject _objectFragment;

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

    protected virtual void OnHitKnifeEnter(Collider2D collision) { }

    protected virtual void OnStart() { }
    protected virtual void OnUpdate() { }
}
