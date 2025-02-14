using System.Collections.Generic;
using UnityEngine;

public class RandomObjectSpawning : MonoBehaviour
{
    [SerializeField]
    GameObject ObjectToSpawn;

    [SerializeField]
    private List<Transform> SpawnLocations;
    [SerializeField]
    int SpawnAmount;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < SpawnAmount; i++)
        {
            Transform SpawnLocation = SpawnLocations[Random.Range(0, SpawnLocations.Count)];
            Instantiate(ObjectToSpawn, SpawnLocation);
            SpawnLocations.Remove(SpawnLocation);
        }
    }
}
