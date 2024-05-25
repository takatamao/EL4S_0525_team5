using Cinemachine;
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
    private GameObject _suka;

    [SerializeField]
    private float _randomRange;

    private CinemachineImpulseSource _impulseSource;

    private Vector3 _originalPos;
    private Quaternion _originalRot;

    // Start is called before the first frame update
    void Start()
    {
        _impulseSource = GetComponent<CinemachineImpulseSource>();

        _originalPos = new Vector3(0f, 0f, -1f);
        _originalRot = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space)) 
        {
            //GenerateSlashEffect();

            //GenerateZaku();
            //GenerateSuka();
        }
    }

    public void GenerateSlashEffect()
    {
        // 斬撃エフェクト
        Instantiate(_effect);
    }

    public void GenerateZaku()
    {
        // ザク文字
        Vector3 randPos = new Vector3(Random.Range(-_randomRange, _randomRange), Random.Range(0, _randomRange), 0f);
        randPos += transform.position;
        Quaternion randRot = new Quaternion(0f, 0f, Random.Range(-0.8f, 0.8f), 1f);
        Instantiate(_zaku, randPos, randRot);

        CameraShake();
    }

    public void GenerateSuka()
    {
        // ザク文字
        Vector3 randPos = new Vector3(Random.Range(-_randomRange, _randomRange), Random.Range(0, _randomRange), 0f);
        randPos += transform.position;
        Quaternion randRot = new Quaternion(0f, 0f, Random.Range(-0.8f, 0.8f), 1f);
        Instantiate(_suka, randPos, randRot);
    }

    public void CameraShake()
    {
        StartCoroutine(_CameraShake());
    }

    IEnumerator _CameraShake()
    {
        _impulseSource.GenerateImpulse();

        yield return new WaitForSeconds(1f);

        Camera.main.transform.position = _originalPos;
        Camera.main.transform.localRotation = _originalRot;
    }
}
