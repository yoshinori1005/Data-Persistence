using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class StartMenu : MonoBehaviour
{
    [SerializeField] private InputField nameInputField;
    [SerializeField] private Text bestScoreText;

    void Start()
    {
        DataManager.LoadData();
        nameInputField.text = DataManager.CurrentData.playerName;
        UpdateBestScore();
    }

    public void OnStartButtonClicked()
    {
        string playerName = nameInputField.text.Trim();

        if (string.IsNullOrEmpty(playerName))
        {
            playerName = "Player";
        }

        DataManager.SaveData(new PlayerData(playerName, DataManager.CurrentData.highScore));

        SceneManager.LoadScene(1);
    }

    public void OnQuitButtonClicked()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    private void UpdateBestScore()
    {
        if (DataManager.CurrentData != null)
        {
            bestScoreText.text = $"Best Score : {DataManager.CurrentData.playerName} : {DataManager.CurrentData.highScore}";
        }
        else
        {
            bestScoreText.text = "No Best Score Yet";
        }
    }
}
