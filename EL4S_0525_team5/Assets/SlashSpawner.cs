using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _effect;

    [SerializeField]
    private GameObject _zaku;

    [SerializeField]
    private float _randomRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space)) 
        {
            // 斬撃エフェクト
            Instantiate(_effect);

            // ザク文字
            Vector3 randPos = new Vector3(Random.Range(-_randomRange, _randomRange), Random.Range(0, _randomRange), 0f);
            randPos += transform.position;
            Quaternion randRot = new Quaternion(0f, 0f, Random.Range(-0.8f, 0.8f), 1f);
            Instantiate(_zaku, randPos, randRot);
        }
    }
}
