using System.Collections.Generic;
using UnityEngine;

public class RandomObjectSpawning : MonoBehaviour
{
    [SerializeField]
    private GameObject _objectToSpawn;

    [SerializeField]
    private List<Transform> _spawnLocations;
    [SerializeField]
    private int _spawnAmount;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _spawnAmount; i++)
        {
            Transform SpawnLocation = _spawnLocations[Random.Range(0, _spawnLocations.Count)];
            Instantiate(_objectToSpawn, SpawnLocation);
            _spawnLocations.Remove(SpawnLocation);
        }
    }
}
