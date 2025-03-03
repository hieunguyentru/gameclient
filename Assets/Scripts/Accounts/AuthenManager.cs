using UnityEngine;
using Unity.Services.Authentication;
using Unity.Services.Core;
using System.Threading.Tasks;
using System;
using UnityEngine.SceneManagement;

public class AuthenManager : MonoBehaviour
{
    async void Start()
    {
        if (!UnityServices.State.Equals(ServicesInitializationState.Initialized))
        {
            await UnityServices.InitializeAsync();
            Debug.Log("Unity Services đã khởi tạo!");
        }

        if (AuthenticationService.Instance.IsSignedIn)
        {
            Debug.Log("Người dùng đã đăng nhập với ID: " + AuthenticationService.Instance.PlayerId);
        }
    }

    public async Task Login(string username, string password)
    {
        try
        {
            await AuthenticationService.Instance.SignInWithUsernamePasswordAsync(username, password);
            Debug.Log("Đăng nhập thành công với ID: " + AuthenticationService.Instance.PlayerId);

            SceneManager.LoadScene("Menu");
        }
        catch (Exception e)  // Bắt tất cả lỗi
        {
            Debug.LogError("Lỗi đăng nhập: " + e.Message);
        }
    }

    public async Task Register(string username, string password)
    {
        try
        {
            await AuthenticationService.Instance.SignUpWithUsernamePasswordAsync(username, password);
            Debug.Log("Đăng ký thành công với tài khoản: " + username);

            SceneManager.LoadScene("Menu");
        }
        catch (Exception e)  // Bắt tất cả lỗi
        {
            Debug.LogError("Đăng ký thất bại: " + e.Message);
        }
    }
}
