using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartLevel1()
    {
        SceneManager.LoadScene("Lv.1");
    }

    public void StartLevel2()
    {
        SceneManager.LoadScene("Lv.2");
    }

    public void StartLevel3()
    {
        SceneManager.LoadScene("Lv.3");
    }


    public void ExitGame()
    {
#if UNITY_EDITOR
        // 在 Editor 裡按 Exit 直接停止播放
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Build 到裝置上時用這個退出
        Application.Quit();
#endif
    }
}
