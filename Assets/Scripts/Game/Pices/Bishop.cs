using UnityEngine;
using System.Collections.Generic;

public class Bishop : ChessPiece
{
    public override List<Vector2Int> GetValidMoves(ChessPiece[,] boardState)
    {
        return GetDiagonalMoves(boardState);
    }
}
