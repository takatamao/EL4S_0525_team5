using UnityEngine;

public class Carrot : GimmickBase
{
    protected override void OnHitKnifeEnter(Collider2D collision)
    {
        if (_objectFragment != null) Instantiate(_objectFragment);
        else Debug.LogError("破片オブジェクトがアタッチされていません！");
        
        Destroy(this.gameObject);
    }
}
