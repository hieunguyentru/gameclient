using UnityEngine;
using System.Collections.Generic;
public class King : ChessPiece
{
    public override List<Vector2Int> GetValidMoves(ChessPiece[,] boardState)
    {
        List<Vector2Int> validMoves = new List<Vector2Int>();

        Vector2Int[] kingMoves =
        {
            new Vector2Int(Position.x + 1, Position.y),
            new Vector2Int(Position.x - 1, Position.y),
            new Vector2Int(Position.x,Position.y + 1),
            new Vector2Int(Position.x, Position.y - 1),
            new Vector2Int(Position.x + 1, Position.y + 1),
            new Vector2Int(Position.x - 1, Position.y - 1),
            new Vector2Int(Position.x + 1, Position.y - 1),
            new Vector2Int(Position.x - 1, Position.y + 1)
        };

        foreach(Vector2Int move in kingMoves)
        {
            if(IsInsideBoard(move) && (boardState[move.x,move.y] == null) || boardState[move.x, move.y].name.Contains(name.Contains("White") ? "Black" : "White"))
            {
                validMoves.Add(move);
            }
        }
        return validMoves;
    }
}
