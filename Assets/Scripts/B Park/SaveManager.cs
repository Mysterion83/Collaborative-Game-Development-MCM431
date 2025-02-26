using UnityEngine;
using System.IO;
using UnityEditor.Build.Content;

public class SaveManager : MonoBehaviour
{
    // Filename
    private string saveFileName = "/savedata.json";

    public void SaveGame()
    {
        SaveData data = new SaveData();

        //Will add data once project is merged
       // data.playerPosition =;  
        //data.playerRotation =; 
       // data.triggeredEvents =; 
        //data.inventoryItems =;

        SettingsMenu settings = FindObjectOfType<SettingsMenu>();
        if(settings != null)
        {
            data.resolutionIndex = settings.resolutionDropdown.value;
            data.graphicsQuality = settings.graphicsDropdown.value;
            data.masterVolume = settings.masterVolumeSlider.value;
            data.sfxVolume = settings.sfxVolumeSlider.value;
            data.musicVolume = settings.musicVolumeSlider.value;
            data.brightness = settings.brightnessSlider.value;
        }

        //Converts SaveData to JSON
        string json = JsonUtility.ToJson(data, true);

        //Writes the JSON to file
        File.WriteAllText(Application.persistentDataPath + saveFileName, json);

        Debug.Log("Game Saved: " + Application.persistentDataPath + saveFileName);
    }

    public void LoadGame()
    {
        string filePath = Application.persistentDataPath + saveFileName;

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);

            SaveData data = JsonUtility.FromJson<SaveData>(json);

            //playerPosition = data.playerPosition
            //playerRotation = data.playerRotation
            //triggeredEvents = data.triggeredEvents
            //inventoryItems = data.inventoryItems            

            Debug.Log("Game Loaded");
        }

        else
        {
            Debug.Log("Save file not found in " + filePath);
        }
    }
}