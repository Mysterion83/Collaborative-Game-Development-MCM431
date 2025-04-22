using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetariumHiddenRoom : MonoBehaviour
{
    [SerializeField] OpenDoor door;
    [SerializeField] CodeLock codeLock;

    private void Update()
    {
        if (!codeLock.solved || !door.locked) return;

        else if (codeLock.solved)
        {
            door.locked = false;
        }
    }
}
