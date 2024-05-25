using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _spawnList;
    [SerializeField] private bool _autoMode = false;
    [SerializeField] private float _spawnRate = 1.0f;
    [SerializeField] private float _destroyTime = 5.0f;
                     private float _originRate;

    // Start is called before the first frame update
    void Start()
    {
        _originRate = _spawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        _spawnRate -= Time.deltaTime;

        if(_autoMode)
        {
            if (_spawnRate <= 0)
            {
                Destroy(Instantiate(_spawnList[Random.Range(0, _spawnList.Length)], this.transform.position, Quaternion.identity),_destroyTime);
                _spawnRate = _originRate;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Destroy(Instantiate(_spawnList[Random.Range(0, _spawnList.Length)], this.transform.position, Quaternion.identity), _destroyTime);
            }
        }

        

       
    }
}
