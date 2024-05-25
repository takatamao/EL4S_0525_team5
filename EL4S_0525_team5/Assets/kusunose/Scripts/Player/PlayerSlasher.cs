using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlasher : MonoBehaviour, ISlashResultApplyable
{
    /// <summary>
    /// �n����U�邤��̃I�u�W�F�N�g
    /// </summary>
    [SerializeField]
    private GameObject handObject;

    Animator animator;
    /// <summary>
    /// �؂铖���蔻��
    /// </summary>
    private BoxCollider2D boxCollider2D;

    /// <summary>
    /// �X�R�A
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
        // �U�艺�낷
        if(Input.GetKeyDown(KeyCode.Space))
        {
            try
            {
                animator.ResetTrigger("trIdle");
                animator.SetTrigger("trCut");
            }
            catch
            {
                Debug.LogError("animator���A�^�b�`����Ă��܂���");
            }

            boxCollider2D.enabled = true;
        }
        //�@�߂�
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            boxCollider2D.enabled = false;
        }
    }

    /// <summary>
    /// �؂������ʂ��󂯂�
    /// </summary>
    /// <param name="damage"></param>
    public void ApplySlashResult(SlashResult slashResult)
    {
        score += (int)slashResult.Score;
        Debug.Log(score);

        // ����
        if(slashResult.IsSuccessed)
        {
            Debug.Log("�J�b�g����");
            audioSource.PlayOneShot(CutAudio_Success);
            //�X�R�A���Z
        }
        // ���s
        else
<<<<<<< HEAD
        {

            

=======
        {
            audioSource.PlayOneShot(CutAudio_Miss);
>>>>>>> kawashima_Scene
            Debug.Log("�J�b�g���s");

            if (slashResult.BlindDuration > 0)
            {
                
                // �߂���܂��̃f�o�t����
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
