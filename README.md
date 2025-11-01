# 🎮 Unity Demo: Editable PlayerPrefs with Live Playtime Display

## 🧠 What Are PlayerPrefs?

`PlayerPrefs` in Unity is a simple and convenient way to store and retrieve small amounts of data between game sessions. It’s commonly used for saving player settings, preferences, and lightweight game progress such as high scores, unlocked levels, or audio volume. Under the hood, `PlayerPrefs` stores data in the operating system’s registry or local files depending on the platform, making it persistent across game launches. It supports three basic data types: `string`, `int`, and `float`, and provides methods like `SetString`, `SetInt`, `SetFloat`, and their corresponding `Get` methods to access stored values.

To use `PlayerPrefs`, developers typically call `PlayerPrefs.SetX` to save a value and `PlayerPrefs.GetX` to retrieve it. For example, saving a player's name would involve `PlayerPrefs.SetString("PlayerName", "Ernst")`, and retrieving it later would use `PlayerPrefs.GetString("PlayerName")`. These calls can be placed in scripts tied to UI buttons, game events, or scene transitions. Although `PlayerPrefs` is not suitable for large or sensitive data, it’s ideal for quick prototyping and storing non-critical information. Developers should always call `PlayerPrefs.Save()` to ensure data is written to disk, especially on platforms where automatic saving isn’t guaranteed.

This Unity demo allows users to enter and save:
- A string for player name
- An integer for level
- A double (stored as float) for points

It also includes:
- A live playtime counter that updates every second
- A button to save the entered data
- A button to load and display saved PlayerPrefs data

---

## 🧰 Requirements

- Unity 2020.3 or newer
- TextMeshPro package (included by default)

---

## 📁 Project Setup

### 1. Create a New Unity Project

- Open Unity Hub → New Project → 2D or 3D
- Name it `PlayerPrefsLiveDemo`
- Click **Create**

### 2. Set Up the Scene

- Rename `SampleScene` to `MainScene`
- Create an empty GameObject named `GameManager`
- Create a Canvas (if not present) and set its **Render Mode** to `Screen Space - Overlay`

---

## 🧵 UI Setup with TextMeshPro

### 3. Add TextMeshPro InputFields

- Right-click on Canvas → UI → **Input Field - TextMeshPro**
  - Rename to `NameInput`
  - Placeholder: `"Enter Name"`
- Duplicate `NameInput` twice and rename:
  - `LevelInput` → `"Enter Level"`
  - `PointsInput` → `"Enter Points"`

### 4. Add Playtime Text

- UI → Text - TextMeshPro → Rename to `PlaytimeText`
  - Set initial text to `"Playtime: 0s"`

### 5. Add Display Text

- UI → Text - TextMeshPro → Rename to `DisplayText`
  - Set text to `"Current PlayerPrefs Data"`

### 6. Add Buttons

- UI → Button - TextMeshPro → Rename to `SaveButton`
  - Text: `"Save Data"`
- UI → Button - TextMeshPro → Rename to `LoadButton`
  - Text: `"Load Data"`

---

## 🧠 Script Setup

### 7. Create a C# Script

- In `Assets/Scripts`, create `PlayerPrefsLiveDemo.cs`
- Attach it to `GameManager`

### 8. Script Contents

```csharp
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
```

---

## 🔗 Hook Up References

### 9. Assign UI Elements in Inspector

1. Select the `GameManager` GameObject in the Hierarchy.
2. In the Inspector, locate the `PlayerPrefsLiveDemo` script component.
3. Drag and drop the following UI elements into their respective fields:
   - `NameInput` → TMP_InputField for player name
   - `LevelInput` → TMP_InputField for level
   - `PointsInput` → TMP_InputField for points
   - `PlaytimeText` → TMP_Text that displays live playtime
   - `DisplayText` → TMP_Text that shows loaded PlayerPrefs data
   - `SaveButton` → Button to trigger saving
   - `LoadButton` → Button to trigger loading

---

## 🧪 Test the Project

### 10. Run and Interact

1. Press **Play** in the Unity Editor.
2. Enter values into the `NameInput`, `LevelInput`, and `PointsInput` fields.
3. Observe the `PlaytimeText` updating every second with elapsed time.
4. Click **Save Data** to store the current values in PlayerPrefs.
5. Click **Load Data** to display the saved values in `DisplayText`.
6. Stop and restart the scene to verify that saved data persists.

---

