using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class zaku : MonoBehaviour
{
    [SerializeField]
    private float _finishTime;

    private CinemachineImpulseSource _impulseSource;

    private Vector3 _originalPos;
    private Quaternion _originalRot;

    // Start is called before the first frame update
    void Start()
    {
        _originalPos = new Vector3(0f,0f,-1f);
        _originalRot = Quaternion.identity;

        _impulseSource = GetComponent<CinemachineImpulseSource>();
        _impulseSource.GenerateImpulse();

        StartCoroutine(Finish());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Finish()
    {
        yield return new WaitForSeconds(_finishTime);

        Destroy(this.gameObject);
        Camera.main.transform.position = _originalPos;
        Camera.main.transform.localRotation = _originalRot;
    }
}
