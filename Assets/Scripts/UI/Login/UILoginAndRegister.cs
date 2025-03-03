using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading.Tasks;
public class UILoginAndRegister : MonoBehaviour
{
    [Header("For Login")]
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public Button loginButton;
    public Button regiterFirstButton;
    public GameObject loginPanel;

    [Header("For Register")]
    public TMP_InputField usernameText;
    public TMP_InputField passwordText;
    public Button registerButton;
    public GameObject registerPanel;

    private AuthenManager authenManager;

    private void Awake()
    {
        authenManager = FindAnyObjectByType<AuthenManager>();
    }
    void Start()
    {
        loginButton.onClick.AddListener(OnLoginButtonClicked);
        registerButton.onClick.AddListener(OnRegisterButtonClicked);
        loginPanel.SetActive(true);
        registerPanel.SetActive(false);
        regiterFirstButton.onClick.AddListener(OnRegisterFirstButtonClicked);
    }

    void OnRegisterFirstButtonClicked()
    {
        loginPanel.SetActive(false);
        registerPanel.SetActive(true);
    }

    async void OnLoginButtonClicked()
    {
        string usename = usernameInput.text;
        string password = passwordInput.text;
        await authenManager.Login(usename,password);
    }

    async void OnRegisterButtonClicked()
    {
        string username = usernameText.text;
        string password = passwordText.text;
        await authenManager.Register(username, password);
    }

    
}
