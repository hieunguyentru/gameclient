using UnityEngine;
using System.Collections.Generic;
public class Rock : ChessPiece
{
    public override List<Vector2Int> GetValidMoves(ChessPiece[,] boardState)
    {
        return GetStraightMoves(boardState);
    }
    
}
