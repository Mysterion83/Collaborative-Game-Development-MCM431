using System.Collections.Generic;
using UnityEngine;

public class RandomObjectSpawning : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _objectsToSpawn;

    [SerializeField]
    private List<Transform> _spawnLocations;

    void Start()
    {
        if (_objectsToSpawn.Count > _spawnLocations.Count)
        {
            Debug.LogError("Random Object Spawning: There are more objects to spawn than spawn locations");
            return;
        }
        for (int i = 0; i < _objectsToSpawn.Count; i++)
        {
            Transform spawnLocation = _spawnLocations[Random.Range(0, _spawnLocations.Count)];
            Instantiate(_objectsToSpawn[0], spawnLocation);
            _spawnLocations.Remove(spawnLocation);
            _objectsToSpawn.RemoveAt(0);
        }
    }
}
