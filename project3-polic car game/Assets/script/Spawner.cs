using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] _enemy; 
    [SerializeField] GameObject[] _spawnPos;
    bool _gameOver;
    void Start()
    {
        InvokeRepeating("spawner", Random.Range(2, 4), Random.Range(0.5f, 1));
    }

    void spawner()
    {
        Instantiate(_enemy[Random.Range(0,3)], _spawnPos[Random.Range(0, 3)].transform.position, Quaternion.identity);
    }
}
