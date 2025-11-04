using UnityEngine;
using TMPro;
using UnityEngine.UI;
// no need to load special library so we can use playerprefs

public class PlayerPrefsLiveDemo : MonoBehaviour
{
    public TMP_InputField nameInput, levelInput, pointsInput;
    public TMP_Text playtimeText, displayText;
    public Button saveButton, loadButton;

    private float playtime = 0f; // need to speficy f because C# expects double by default

    void Start()
    {
        saveButton.onClick.AddListener(SaveData); // registers an event listener that triggers when the save
                                                  // button  is clicked; call  SaveData function
        loadButton.onClick.AddListener(LoadData); // registers an event listener that triggers when the
                                                  // load button is clicked; calls  the loadData function
    }

    void Update()
    {
        playtime += Time.deltaTime; // : The time (in seconds) that has passed since the last frame.
                                    // Unity updates this value every frame. results in smoother game play
                                    // fixedDeltaTime runs at a constant rate (default: 0.02 seconds or 50 times per second).
                                    // important when time precision is required
        playtimeText.text = $"Playtime: {Mathf.FloorToInt(playtime)}s"; // This converts a floating-point number (playtime)
                                                                        // into an integer by rounding it down to the nearest whole number.
    }

    void SaveData()
    {
        PlayerPrefs.SetString("PlayerName", nameInput.text); //saves a string value (the player's name)
                                                             //into Unity's PlayerPrefs system
                                                             // on windows: HKEY_CURRENT_USER\Software
                                                             // \[CompanyName]
                                                             // \[ProductName]

        PlayerPrefs.SetInt("Level", int.Parse(levelInput.text));
        PlayerPrefs.SetFloat("Points", float.Parse(pointsInput.text));
        PlayerPrefs.SetFloat("Playtime", playtime);
        PlayerPrefs.Save();
        Debug.Log("Data Saved"); // so you can check the console
    }

    void LoadData()
    {
        string name = PlayerPrefs.GetString("PlayerName", "DefaultName"); //retrieves a saved string value
                                                                          //from Unity's PlayerPrefs system. Defaultname
                                                                          // is a fallback value, used if no value is 
                                                                          // under PlayerName


        int level = PlayerPrefs.GetInt("Level", 1);
        float points = PlayerPrefs.GetFloat("Points", 0f);
        float savedPlaytime = PlayerPrefs.GetFloat("Playtime", 0f);

        // The $  enables string interpolation
        // {name} tells the compiler:"Insert the value of the variable name". it is a placeholder
        // F2 formats string to display the number as a fixed-point number with 2 decimal places.
        displayText.text = $"Name: {name}\nLevel: {level}\nPoints: {points:F2}\nPlaytime: {Mathf.FloorToInt(savedPlaytime)}s";
    }
}
