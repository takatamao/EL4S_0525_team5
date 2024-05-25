using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlasher : MonoBehaviour
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
}
