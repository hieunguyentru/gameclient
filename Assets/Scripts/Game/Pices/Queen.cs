using UnityEngine;
using System.Collections.Generic;

public class Queen : ChessPiece
{
    public override List<Vector2Int> GetValidMoves(ChessPiece[,] boardState)
    {
        List<Vector2Int> validMoves = new List<Vector2Int>();
        validMoves.AddRange(GetStraightMoves(boardState));
        validMoves.AddRange(GetDiagonalMoves(boardState));
        return validMoves;
    }
}
