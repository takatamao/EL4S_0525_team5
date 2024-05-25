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

    Animator animator;
    /// <summary>
    /// 切る当たり判定
    /// </summary>
    private BoxCollider2D boxCollider2D;

    /// <summary>
    /// スコア
    /// </summary>
    private int score = 0;

    public int Score => score;
    private SlashSpawner _spawner;


    [SerializeField]
    AudioClip CutAudio_Success;
    [SerializeField]
    AudioClip CutAudio_Miss;

    AudioSource audioSource;

    void Start()
    {
        _spawner = GameObject.FindWithTag("ES").GetComponent<SlashSpawner>();

        boxCollider2D = handObject.GetComponent<BoxCollider2D>();
        boxCollider2D.enabled = false;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // 振り下ろす
        if(Input.GetKeyDown(KeyCode.Space))
        {
            try
            {
                animator.ResetTrigger("trIdle");
                animator.SetTrigger("trCut");
            }
            catch
            {
                Debug.LogError("animatorがアタッチされていません");
            }

            boxCollider2D.enabled = true;
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
        score += (int)slashResult.Score;
        Debug.Log(score);

        // 成功
        if(slashResult.IsSuccessed)
        {
            Debug.Log("カット成功");
            audioSource.PlayOneShot(CutAudio_Success);
            //スコア加算
        }
        // 失敗
        else
<<<<<<< HEAD
        {

            

=======
        {
            audioSource.PlayOneShot(CutAudio_Miss);
>>>>>>> kawashima_Scene
            Debug.Log("カット失敗");

            if (slashResult.BlindDuration > 0)
            {
                
                // めくらましのデバフ処理
            }
        }

    }

    void OnCutBegin()
    {
        animator.ResetTrigger("trCut");
        animator.SetTrigger("trIdle");
        //boxCollider2D.enabled = true;



#if UNITY_EDITOR
        Vector2 leftTop = (Vector2)handObject.transform.position + boxCollider2D.size / 2;
        Vector2 rightBotom = (Vector2)handObject.transform.position - boxCollider2D.size / 2;
        ShapeGizmo.DrawWire2DRect(leftTop, rightBotom, Color.red);
#endif
        Invoke("OnCutEnd", 0.1f);   
    }

    void OnCutEnd()
    {
        //boxCollider2D.enabled = false;
    }
}
