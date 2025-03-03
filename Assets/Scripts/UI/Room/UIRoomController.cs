using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIRoomController : MonoBehaviour
{
    public Image playerImage;

    public TextMeshProUGUI playerText;

    public TextMeshProUGUI ScoreText;

    public Button findButton;

    public GameObject timerPanel;
    void Start()
    {
        findButton.onClick.AddListener(OnFindButtonClicked);
    }

    void OnFindButtonClicked()
    {
        timerPanel.SetActive(true);
    }    

    // Update is called once per frame
    void Update()
    {
        
    }
}
