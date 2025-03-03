using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Button startButton;
    public Button settingButton;
    public Button exitButton;

    public Button imagePlayerButton;
    public Button saveButton;

    public GameObject menuPanel;
    public GameObject imagePlayerPanel;

    public AvatarSelection avatarSelection;
    void Start()
    {
        startButton.onClick.AddListener(OnStartButtonClicked);
        settingButton.onClick.AddListener(OnSettingButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
        imagePlayerButton.onClick.AddListener(OnImagePlayerButtonClicked);
        saveButton.onClick.AddListener(OnSaveButtonClicked);

        menuPanel.SetActive(true);
        imagePlayerPanel.SetActive(false);
    }

    void OnStartButtonClicked()
    {
        SceneManager.LoadScene("MenuMode");
        Debug.Log("Đang chuyển sang Chế độ chơi");
    }

    void OnSettingButtonClicked()
    {
        SceneManager.LoadScene("SettingMode");
        Debug.Log("Đang chuyển sang Chế độ Cài đặt");
    }
    
    void OnExitButtonClicked()
    {
        Application.Quit();
        Debug.Log("Đang thoát trò chơi xin chờ ...");
    }

    void OnImagePlayerButtonClicked()
    {
        menuPanel.SetActive(false);
        imagePlayerPanel.SetActive(true);
       
    }
    
    void OnSaveButtonClicked()
    {
        avatarSelection.SaveAvatar();
    }    

}
