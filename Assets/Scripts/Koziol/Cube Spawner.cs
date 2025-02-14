using System;
using UnityEngine;

[Obsolete("CubeSpawner is a temporary system for physics testing. Do not use it in production code and prefabs.", false)]
public class CubeSpawner : MonoBehaviour
{
    [SerializeField]
    int x, y, z;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Spawn();
    }
    void Spawn()
    {
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                for (int k = 0; k < z; k++)
                {
                    GameObject a = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    a.AddComponent<Rigidbody>();
                    a.transform.position = new Vector3(i + transform.position.x, j + transform.position.y, k + transform.position.z);
                }
            }
        }
    }
}
