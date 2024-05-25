using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _spawnList;
    [SerializeField] private GameObject[] _cutableList;
    [SerializeField] private GameObject[] _notCutableList;
    [SerializeField] private float _maxSpawnRate = 3.0f;
    [SerializeField] private float _minSpawnRate = 0.1f;
    [SerializeField] private float _destroyTime = 5.0f;
                     private float _coolTimer;

    [SerializeField] private bool _autoMode = true;

    // Start is called before the first frame update
    void Start()
    {
        _coolTimer = Random.Range(_minSpawnRate, _maxSpawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        _coolTimer -= Time.deltaTime;

        if(_autoMode)
        {
            if (_coolTimer <= 0)
            {
                Destroy(Instantiate(_spawnList[Random.Range(0, _spawnList.Length)], this.transform.position, Quaternion.identity),_destroyTime);
                _coolTimer = Random.Range(_minSpawnRate, _maxSpawnRate);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Destroy(Instantiate(_spawnList[Random.Range(0, _cutableList.Length)], this.transform.position, Quaternion.identity), _destroyTime);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Destroy(Instantiate(_spawnList[Random.Range(0, _notCutableList.Length)], this.transform.position, Quaternion.identity), _destroyTime);
            }
        }

        

       
    }
}
