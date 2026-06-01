using UnityEngine;
using System.IO;

[System.Serializable]
public class SaveData
{
    public float playerX;
    public float playerY;
    public float playerZ;

    public bool hasTalkedToNPC;

    public int symbolsDiscovered;
}

public class SaveManager : MonoBehaviour
{
    public Transform player;

    public SaveData data = new SaveData();

    string savePath;

    void Start()
    {
        savePath = Application.persistentDataPath + "/save.json";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            SaveGame();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadGame();
        }
    }

    public void SaveGame()
    {
        data.playerX = player.position.x;
        data.playerY = player.position.y;
        data.playerZ = player.position.z;

        data.hasTalkedToNPC = true;
        data.symbolsDiscovered = 3;

        string json = JsonUtility.ToJson(data, true);

        File.WriteAllText(savePath, json);

        Debug.Log("Game Saved!");

        PlayerPrefs.SetInt("HasWon", 1);
        PlayerPrefs.Save();
    }

    public void LoadGame()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);

            data = JsonUtility.FromJson<SaveData>(json);

            player.position = new Vector3(
                data.playerX,
                data.playerY,
                data.playerZ
            );

            Debug.Log("Game Loaded!");

            Debug.Log("Talked To NPC: " + data.hasTalkedToNPC);
            Debug.Log("Symbols Discovered: " + data.symbolsDiscovered);
        }
        else
        {
            Debug.Log("No save file found!");
        }

        int hasWon = PlayerPrefs.GetInt("HasWon", 0);

        Debug.Log("HasWon PlayerPref: " + hasWon);
    }
}