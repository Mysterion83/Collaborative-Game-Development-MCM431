using System.Collections.Generic;
using System.Numerics;

[System.Serializable]
public class SaveData
{
    //Player Data
    public Vector3 playerPosition;
    public Quaternion playerRotation;

    //Inventory Data
    public List<ItemData> inventoryItems;

    //World Data
    public List<WorldEvent> triggeredEvents;

    //Settings Data
    public int resolutionIndex;
    public int graphicsQuality;
    public float masterVolume;
    public float sfxVolume;
    public float musicVolume;
    public float brightness;
}

[System.Serializable]
public class ItemData
{
    public string itemID;
    public int quantity;
}

[System.Serializable]
public class WorldEvent
{
    public string eventID;
    public bool hasBeenTriggered;
}