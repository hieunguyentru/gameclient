using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerController : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float elapsedTime = 0f;
    private bool isSearching = true;

    public void StartTimer()
    {
        elapsedTime = 0f;
        isSearching = true;
    }

    private void Update()
    {
        if(isSearching)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerUI();
        }    
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        timerText.text = string.Format("{00:00}:{1:00}", minutes, seconds);
    }

    public void StopTimer()
    {
        isSearching = false;   
    }    


}
