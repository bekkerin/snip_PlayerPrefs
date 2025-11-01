using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerPrefsLiveDemo : MonoBehaviour
{
    public TMP_InputField nameInput, levelInput, pointsInput;
    public TMP_Text playtimeText, displayText;
    public Button saveButton, loadButton;

    private float playtime = 0f;

    void Start()
    {
        saveButton.onClick.AddListener(SaveData);
        loadButton.onClick.AddListener(LoadData);
    }

    void Update()
    {
        playtime += Time.deltaTime;
        playtimeText.text = $"Playtime: {Mathf.FloorToInt(playtime)}s";
    }

    void SaveData()
    {
        PlayerPrefs.SetString("PlayerName", nameInput.text);
        PlayerPrefs.SetInt("Level", int.Parse(levelInput.text));
        PlayerPrefs.SetFloat("Points", float.Parse(pointsInput.text));
        PlayerPrefs.SetFloat("Playtime", playtime);
        PlayerPrefs.Save();
        Debug.Log("Data Saved");
    }

    void LoadData()
    {
        string name = PlayerPrefs.GetString("PlayerName", "DefaultName");
        int level = PlayerPrefs.GetInt("Level", 1);
        float points = PlayerPrefs.GetFloat("Points", 0f);
        float savedPlaytime = PlayerPrefs.GetFloat("Playtime", 0f);

        displayText.text = $"Name: {name}\nLevel: {level}\nPoints: {points:F2}\nPlaytime: {Mathf.FloorToInt(savedPlaytime)}s";
    }
}
