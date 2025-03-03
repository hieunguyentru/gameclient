using System.Collections.Generic;
using UnityEngine;

public abstract class ChessPiece : MonoBehaviour
{
    public Vector2Int Position { get; private set; }
    public bool IsWhite { get; private set; }
    private List<GameObject> moveIndicators = new List<GameObject>();

    public void SetPosition(Vector2Int newPosition) => Position = newPosition;
    public bool IsEnemy(ChessPiece other) => other != null && other.IsWhite != IsWhite;

    public abstract List<Vector2Int> GetValidMoves(ChessPiece[,] boardState);

    protected bool IsInsideBoard(Vector2Int pos) => pos.x >= 0 && pos.x < 8 && pos.y >= 0 && pos.y < 8;

    protected List<Vector2Int> GetDirectionalMoves(ChessPiece[,] boardState, Vector2Int[] directions)
    {
        List<Vector2Int> validMoves = new List<Vector2Int>();

        foreach (Vector2Int dir in directions)
        {
            Vector2Int newPos = Position;
            while (true)
            {
                newPos += dir;
                if (!IsInsideBoard(newPos)) break;

                ChessPiece targetPiece = boardState[newPos.x, newPos.y];
                if (targetPiece != null)
                {
                    if (IsEnemy(targetPiece)) validMoves.Add(newPos);
                    break;
                }
                validMoves.Add(newPos);
            }
        }

        Debug.Log($"{name} có {validMoves.Count} nước đi hợp lệ");
        return validMoves;
    }

    protected List<Vector2Int> GetStraightMoves(ChessPiece[,] boardState) =>
        GetDirectionalMoves(boardState, new Vector2Int[] { Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right });

    protected List<Vector2Int> GetDiagonalMoves(ChessPiece[,] boardState) =>
        GetDirectionalMoves(boardState, new Vector2Int[] { new Vector2Int(1, 1), new Vector2Int(-1, 1), new Vector2Int(1, -1), new Vector2Int(-1, -1) });

    public void SetColor(bool isWhite)
    {
        IsWhite = isWhite;
        Debug.Log($"{name} được gán màu: {(IsWhite ? "Trắng" : "Đen")}");
    }

    public void ShowMoveIndicators(List<Vector2Int> validMoves, GameObject checkPrefab, Transform parent)
    {
        ClearMoveIndicators();
        foreach (Vector2Int move in validMoves)
        {
            GameObject indicatorObject = Instantiate(checkPrefab, parent);
            if (indicatorObject.TryGetComponent(out MoveIndicator indicator))
            {
                indicator.SetPosition(move);
                moveIndicators.Add(indicatorObject);
            }
            Debug.Log($"Nước đi hợp lệ: {move}");
        }
    }

    public void ClearMoveIndicators()
    {
        foreach (GameObject indicator in moveIndicators) Destroy(indicator);
        moveIndicators.Clear();
    }
}
