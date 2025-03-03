using System.Collections.Generic;
using UnityEngine;

public class Pawn : ChessPiece
{
    public override List<Vector2Int> GetValidMoves(ChessPiece[,] boardState)
    {
        List<Vector2Int> validMoves = new List<Vector2Int>();
        int direction = IsWhite ? 1 : -1;

        // Nước đi thẳng
        TryAddMove(validMoves, boardState, new Vector2Int(Position.x, Position.y + direction));

        // Nước đi 2 ô khi chưa di chuyển
        if ((IsWhite && Position.y == 1) || (!IsWhite && Position.y == 6))
        {
            TryAddMove(validMoves, boardState, new Vector2Int(Position.x, Position.y + (2 * direction)));
        }

        // Nước ăn chéo
        Vector2Int[] attackMoves = {
            new Vector2Int(Position.x - 1, Position.y + direction),
            new Vector2Int(Position.x + 1, Position.y + direction)
        };

        foreach (Vector2Int attackMove in attackMoves)
        {
            if (IsInsideBoard(attackMove) && IsEnemy(boardState[attackMove.x, attackMove.y]))
            {
                validMoves.Add(attackMove);
            }
        }

        return validMoves;
    }

    private void TryAddMove(List<Vector2Int> moves, ChessPiece[,] boardState, Vector2Int move)
    {
        if (IsInsideBoard(move) && boardState[move.x, move.y] == null)
        {
            moves.Add(move);
        }
    }
}
