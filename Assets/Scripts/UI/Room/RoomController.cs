/*using UnityEngine;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using Unity.Services.Authentication;
using Unity.Services.Core;
using System.Threading.Tasks;
using System.Collections.Generic;

public class RoomController : MonoBehaviour
{
    public TimerController timerController;
    private Lobby currentLobby;
    private string playerID;

    async void Start()
    {
        await InitializeUnityServices();
        await EnsureUserLoggedIn();
        await FindOrCreateLobby();
    }

    private async Task InitializeUnityServices()
    {
        if (UnityServices.State != ServicesInitializationState.Initialized)
        {
            await UnityServices.InitializeAsync();
            Debug.Log("✅ Unity Services đã khởi tạo!");
        }
    }

    private async Task EnsureUserLoggedIn()
    {
        if (!AuthenticationService.Instance.IsSignedIn)
        {
            Debug.LogError("❌ Người chơi chưa đăng nhập! Hãy đăng nhập trước khi tìm trận.");
            return;
        }

        playerID = AuthenticationService.Instance.PlayerId;
        Debug.Log("✅ Đăng nhập thành công! Player ID: " + playerID);
    }

    private async Task FindOrCreateLobby()
    {
        if (!AuthenticationService.Instance.IsSignedIn)
        {
            Debug.LogError("❌ Không thể tìm trận vì người chơi chưa đăng nhập!");
            return;
        }

        timerController.StartTimer();
        Debug.Log("🔍 Đang tìm lobby...");

        try
        {
            QueryLobbiesOptions options = new QueryLobbiesOptions
            {
                Count = 1,
                Filters = new List<QueryFilter>
                {
                    new QueryFilter(QueryFilter.FieldOptions.AvailableSlots, "0", QueryFilter.OpOptions.GT)
                }
            };

            QueryResponse lobbyQuery = await LobbyService.Instance.QueryLobbiesAsync(options);

            if (lobbyQuery.Results.Count > 0)
            {
                // Tham gia lobby có sẵn
                currentLobby = await LobbyService.Instance.JoinLobbyByIdAsync(lobbyQuery.Results[0].Id);
                Debug.Log("✅ Tham gia lobby: " + currentLobby.Id);
            }
            else
            {
                // Tạo lobby mới
                CreateLobbyOptions createOptions = new CreateLobbyOptions
                {
                    IsPrivate = false
                };

                currentLobby = await LobbyService.Instance.CreateLobbyAsync("ChessMatch", 2, createOptions);
                Debug.Log("🎉 Tạo lobby mới: " + currentLobby.Id);
            }
        }
        catch (LobbyServiceException e)
        {
            Debug.LogError("❌ Lỗi lobby: " + e.Message);
        }

        timerController.StopTimer();
    }
}
*/