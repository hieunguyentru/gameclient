using UnityEngine;
using UnityEngine.UI;

public class MoveIndicator : MonoBehaviour
{
    public Vector2Int Position {  get; private set; }

    public Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnIndicatorClick);
    }

    public void SetPosition(Vector2Int position)
    {
        Position = position;
        transform.localPosition = GameManager.Instance.pieceManager.GetBoardPosition(position.x, position.y);
    }

    public void DestroiIndicator()
    {
        Destroy(gameObject);
    }

    private void OnIndicatorClick()
    {
        GameManager.Instance.MoveSelectedPiece(Position);
    }    
}
