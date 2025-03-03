using UnityEngine;
using UnityEngine.UI;

public class AvatarScrollView : MonoBehaviour
{
    public GameObject avatarPrefab; // Prefab chứa Image + Button
    public Transform contentPanel; // Content trong Scroll View
    public AvatarSelection avatarSelection; // Script xử lý chọn avatar
    public Sprite[] avatarSprites;

    void Start()
    {
        LoadAvatars();
    }

    void LoadAvatars()
    {
        

        foreach (Sprite avatar in avatarSprites)
        {
            GameObject newAvatar = Instantiate(avatarPrefab,contentPanel);
            Image avatarImage = newAvatar.GetComponent<Image>();
            avatarImage.sprite = avatar;

            Button button = newAvatar.GetComponent<Button>();
            button.onClick.AddListener(() => avatarSelection.SelectAvatar(avatar));
        }
    }
}
