using UnityEngine;

public class PiecesPosition : MonoBehaviour
{
    public GameObject[] whitePieces;
    public GameObject[] blackPieces;
    public RectTransform boardTransform;  // Bàn cờ trong Canvas
    public Transform piecesParent; // Nhóm quân cờ trong Canvas

    private float tileSize;
    private Vector2 boardStartPos;

    void Start()
    {
        if (boardTransform == null || piecesParent == null)
        {
            Debug.LogError("Board hoặc Pieces Parent chưa được gán!");
            return;
        }

       

        SpawnAllPieces();
    }

    private void SpawnAllPieces()
    {
        SpawnPawns();
        SpawnRooks();
        SpawnKnights();
        SpawnBishops();
        SpawnQueens();
        SpawnKings();
    }

    private void SpawnPawns()
    {
        for (int i = 0; i < 8; i++)
        {
            Debug.Log($"Spawn White Pawn tại ({i},1)");
            SpawnPiece(whitePieces[0], i, 1);

            Debug.Log($"Spawn Black Pawn tại ({i},6)");
            SpawnPiece(blackPieces[0], i, 6);
        }
    }


    private void SpawnRooks()
    {
        int[] xPositions = { 0, 7 };
        foreach (int x in xPositions)
        {
            SpawnPiece(whitePieces[1], x, 0);
            SpawnPiece(blackPieces[1], x, 7);
        }
    }

    private void SpawnKnights()
    {
        int[] xPositions = { 1, 6 };
        foreach (int x in xPositions)
        {
            SpawnPiece(whitePieces[2], x, 0);
            SpawnPiece(blackPieces[2], x, 7);
        }
    }

    private void SpawnBishops()
    {
        int[] xPositions = { 2, 5 };
        foreach (int x in xPositions)
        {
            SpawnPiece(whitePieces[3], x, 0);
            SpawnPiece(blackPieces[3], x, 7);
        }
    }

    private void SpawnQueens()
    {
        SpawnPiece(whitePieces[4], 3, 0);
        SpawnPiece(blackPieces[4], 3, 7);
    }

    private void SpawnKings()
    {
        SpawnPiece(whitePieces[5], 4, 0);
        SpawnPiece(blackPieces[5], 4, 7);
    }

    private void SpawnPiece(GameObject piecePrefab, int x, int y)
    {
        if (piecePrefab == null)
        {
            Debug.LogError($"❌ Thiếu prefab cho quân cờ tại ({x}, {y})");
            return;
        }

        Vector2 position = GetBoardPosition(x, y);
        GameObject piece = Instantiate(piecePrefab, piecesParent);
        RectTransform pieceRect = piece.GetComponent<RectTransform>();

        if (pieceRect != null)
        {
            pieceRect.anchoredPosition = position;
            pieceRect.localScale = new Vector3(0.8f, 0.8f, 1);
        }
        else
        {
            Debug.LogError($"❌ Prefab {piecePrefab.name} thiếu RectTransform!");
        }

        Debug.Log($"✅ Spawn: {piecePrefab.name} tại Grid ({x}, {y}) - World {position}");
    }




    public Vector2 GetBoardPosition(int x, int y)
    {
        RectTransform boardRect = boardTransform.GetComponent<RectTransform>();

        float tileSize = (boardRect.rect.width / 8f) * 0.9f; // Giữ khoảng cách các ô hợp lý
        Vector2 startPos = new Vector2(-boardRect.rect.width / 2 + tileSize / 2,
                                        boardRect.rect.height / 2 - tileSize / 2);

        float xOffset = 40f; // Dịch sang phải 15 pixel
        float yOffset = -40f; // Dịch xuống dưới 20 pixel

        return new Vector2(startPos.x + (x * tileSize) + xOffset,
                           startPos.y - (y * tileSize) + yOffset);
    }



}
