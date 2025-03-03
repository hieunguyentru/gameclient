using UnityEngine;
using UnityEngine.UI;

public class AvatarSelection : MonoBehaviour
{
    public Image realImage;
    public UIManager uIManager;
  
    public void SelectAvatar(Sprite avatarSprite)
    {
        if(realImage != null)
        {
            realImage.sprite = avatarSprite;
        }    
    }

    public void SaveAvatar()
    {
        if (realImage != null && realImage.sprite != null)
        {
            // Cập nhật avatar trên UIManager (imagePlayerButton)
            uIManager.imagePlayerButton.GetComponent<Image>().sprite = realImage.sprite;

            // Lưu avatar vào PlayerPrefs
            PlayerPrefs.SetString("SelectedAvatar", realImage.sprite.name);
            PlayerPrefs.Save();

            uIManager.menuPanel.SetActive(true);
            uIManager.imagePlayerPanel.SetActive(false);
        }
    }



}
