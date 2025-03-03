using System.Collections.Generic;
using UnityEngine;

public class Knight : ChessPiece
{
    public override List<Vector2Int> GetValidMoves(ChessPiece[,] boardState)
    {
        List<Vector2Int> validMoves = new List<Vector2Int>();

        Vector2Int[] knightMoves = {
            new Vector2Int(Position.x + 2, Position.y + 1),
            new Vector2Int(Position.x + 2, Position.y - 1),
            new Vector2Int(Position.x - 2, Position.y + 1),
            new Vector2Int(Position.x - 2, Position.y - 1),
            new Vector2Int(Position.x + 1, Position.y + 2),
            new Vector2Int(Position.x + 1, Position.y - 2),
            new Vector2Int(Position.x - 1, Position.y + 2),
            new Vector2Int(Position.x - 1, Position.y - 2)
        };

        foreach (Vector2Int move in knightMoves)
        {
            if (IsInsideBoard(move) && (boardState[move.x, move.y] == null ||
                boardState[move.x, move.y].name.Contains(name.Contains("White") ? "Black" : "White")))
            {
                validMoves.Add(move);
            }
        }

        return validMoves;
    }
}

