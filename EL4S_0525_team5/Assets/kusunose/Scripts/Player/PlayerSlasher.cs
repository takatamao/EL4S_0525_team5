using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlasher : MonoBehaviour, ISlashResultApplyable
{
    /// <summary>
    /// 刃物を振るう手のオブジェクト
    /// </summary>
    [SerializeField]
    private GameObject handObject;

    /// <summary>
    /// 切る当たり判定
    /// </summary>
    private BoxCollider2D boxCollider2D;

    void Start()
    {
        boxCollider2D = handObject.GetComponent<BoxCollider2D>();
        boxCollider2D.enabled = false;
    }

    void Update()
    {
        // 振り下ろす
        if(Input.GetKeyDown(KeyCode.Space))
        {
            boxCollider2D.enabled = true;

#if UNITY_EDITOR
            Vector2 leftTop = (Vector2)handObject.transform.position + boxCollider2D.size / 2;
            Vector2 rightBotom = (Vector2)handObject.transform.position - boxCollider2D.size / 2;
            ShapeGizmo.DrawWire2DRect(leftTop, rightBotom, Color.red);
#endif

        }
        //　戻す
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            boxCollider2D.enabled = false;
        }
    }

    /// <summary>
    /// 切った結果を受ける
    /// </summary>
    /// <param name="damage"></param>
    public void ApplySlashResult(SlashResult slashResult)
    {
        // 成功
        if(slashResult.IsSuccessed)
        {
            Debug.Log("カット成功");
            //スコア加算
        }
        // 失敗
        else
        {
            Debug.Log("カット失敗:切っちゃダメ");
            if (slashResult.BlindDuration > 0)
            {
                // めくらましのデバフ処理
            }
        }

    }
}
