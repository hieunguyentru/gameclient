using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public ChessPiece selectedPiece;
    public PiecesPosition pieceManager;
    public GameObject checkPrefab;

    private bool isWhiteTurn = true;
    private ChessPiece[,] boardState = new ChessPiece[8, 8];
    private List<GameObject> moveIndicators = new List<GameObject>();
    private Camera mainCamera;

    private float tileSize;
    private Vector2 startPos;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        mainCamera = Camera.main;
    }

    private void Start()
    {
        InitializeBoardState();

        tileSize = pieceManager.boardTransform.rect.width / 2;
        startPos = new Vector2(-pieceManager.boardTransform.rect.width / 2, pieceManager.boardTransform.rect.height / 2);
    }

    private void Update()
    {
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed)
        {
            HandleInput(Touchscreen.current.primaryTouch.position.ReadValue());
        }
        else if (Mouse.current != null && Mouse.current.leftButton.isPressed)
        {
            HandleInput(Mouse.current.position.ReadValue());
        }
    }

    private void HandleInput(Vector2 inputPosition)
    {
        Vector2 worldPosition = mainCamera.ScreenToWorldPoint(inputPosition);
        Vector2Int gridPos = GetGridPosition(worldPosition);

        Debug.Log($"Click tại: {gridPos}");

        if (selectedPiece == null)
        {
            SelectPiece(gridPos);
        }
        else
        {
            MoveSelectedPiece(gridPos);
        }
    }

    private void InitializeBoardState()
    {
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                boardState[x, y] = null;  // Reset board trước khi gán
            }
        }

        foreach (Transform piece in pieceManager.piecesParent)
        {
            ChessPiece chessPiece = piece.GetComponent<ChessPiece>();
            if (chessPiece != null)
            {
                Vector2Int pos = GetGridPosition(chessPiece.transform.position);
                chessPiece.SetPosition(pos);
                boardState[pos.x, pos.y] = chessPiece;

                Debug.Log($"📌 {chessPiece.name} gán vào boardState[{pos.x}, {pos.y}]");
            }
        }
    }







    private void SelectPiece(Vector2Int gridPos)
    {
        Debug.Log($"Đang kiểm tra ô {gridPos}");

        if (gridPos.x < 0 || gridPos.x >= 8 || gridPos.y < 0 || gridPos.y >= 8)
        {
            Debug.Log("❌ Vị trí ngoài phạm vi bàn cờ!");
            return;
        }

        ChessPiece piece = boardState[gridPos.x, gridPos.y];

        if (piece == null)
        {
            Debug.Log("❌ Không có quân cờ tại vị trí này!");
            return;
        }

        Debug.Log($"✅ Quân cờ tìm thấy: {piece.name}, Màu: {(piece.IsWhite ? "Trắng" : "Đen")}");

        if (piece.IsWhite != isWhiteTurn)
        {
            Debug.Log("❌ Không phải lượt của bạn!");
            return;
        }

        selectedPiece?.ClearMoveIndicators();
        selectedPiece = piece;
        List<Vector2Int> validMoves = piece.GetValidMoves(boardState);
        Debug.Log($"♟️ Quân {piece.name} có {validMoves.Count} nước đi hợp lệ");
        ShowMoveIndicators(validMoves);
    }


    public void MoveSelectedPiece(Vector2Int targetPos)
    {
        if (selectedPiece != null && IsMoveValid(selectedPiece, targetPos))
        {
            Debug.Log($"Di chuyển {selectedPiece.name} đến {targetPos}");
            ChessPiece targetPiece = boardState[targetPos.x, targetPos.y];
            if (targetPiece != null)
            {
                Debug.Log($"Ăn quân {targetPiece.name}");
                Destroy(targetPiece.gameObject);
            }
            boardState[selectedPiece.Position.x, selectedPiece.Position.y] = null;
            selectedPiece.SetPosition(targetPos);
            boardState[targetPos.x, targetPos.y] = selectedPiece;
            selectedPiece.transform.position = GetWorldPosition(targetPos);

            isWhiteTurn = !isWhiteTurn;
        }
        else
        {
            Debug.Log("Nước đi không hợp lệ");
        }
        selectedPiece = null;
        ClearMoveIndicators();
    }

    private bool IsMoveValid(ChessPiece piece, Vector2Int targetPos)
    {
        return piece.GetValidMoves(boardState).Contains(targetPos);
    }

    private void ShowMoveIndicators(List<Vector2Int> validMoves)
    {
        ClearMoveIndicators();
        Debug.Log($"Hiển thị {validMoves.Count} nước đi");
        foreach (Vector2Int move in validMoves)
        {
            GameObject indicator = Instantiate(checkPrefab, pieceManager.piecesParent);
            MoveIndicator moveIndicator = indicator.GetComponent<MoveIndicator>();
            if (moveIndicator != null)
            {
                moveIndicator.SetPosition(move);
            }
            moveIndicators.Add(indicator);
        }
    }

    private void ClearMoveIndicators()
    {
        foreach (GameObject indicator in moveIndicators)
        {
            Destroy(indicator);
        }
        moveIndicators.Clear();
    }

    private Vector2Int GetGridPosition(Vector2 worldPos)
    {
        float tileSize = pieceManager.boardTransform.rect.width / 8f;
        Vector2 startPos = new Vector2(-pieceManager.boardTransform.rect.width / 2, pieceManager.boardTransform.rect.height / 2);

        Vector2Int gridPos = new Vector2Int(
            Mathf.FloorToInt((worldPos.x - startPos.x) / tileSize),
            Mathf.FloorToInt((startPos.y - worldPos.y) / tileSize)
        );

        Debug.Log($"📌 Convert worldPos {worldPos} -> GridPos {gridPos}");
        return gridPos;
    }





    private Vector2 GetWorldPosition(Vector2Int gridPos)
    {
        return pieceManager.GetBoardPosition(gridPos.x, gridPos.y);
    }
}
