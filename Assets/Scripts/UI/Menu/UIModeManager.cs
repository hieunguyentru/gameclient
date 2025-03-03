using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIModeManager : MonoBehaviour
{
    public Button computerButton;
    public Button playRankButton;
    public Button friendButton;
    public Button backButton;
    public Button testButton;
    void Start()
    {
        computerButton.onClick.AddListener(OnComputerButtonClicked);
        playRankButton.onClick.AddListener(OnPlayRankButtonClicked);
        friendButton.onClick.AddListener(OnFriendButtonClicked);
        backButton.onClick.AddListener(OnBackButtonClicked);
        testButton.onClick.AddListener(OnTestButtonClicked);
    }

    void OnComputerButtonClicked()
    {
        SceneManager.LoadScene("PVE");
        Debug.Log("Đang chuyển sang chế độ đấu với máy");
    }

    void OnPlayRankButtonClicked()
    {
        SceneManager.LoadScene("Room");
        Debug.Log("Đang vào phỏng chờ");
    }

    void OnFriendButtonClicked()
    {
        SceneManager.LoadScene("WithFriendGame");

        Debug.Log("Đang chuyển sang chế độ chơi với bạn");
    }


    void OnBackButtonClicked()
    {
        SceneManager.LoadScene("Menu");

        Debug.Log("Đang chuyển về màn Menu");

    }
    void OnTestButtonClicked()
    {
        SceneManager.LoadScene("GameRank");
    }    
}
