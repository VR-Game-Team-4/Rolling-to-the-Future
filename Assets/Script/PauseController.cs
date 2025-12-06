using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    [Header("UI Root")]
    public GameObject pauseBoard;      // 拖 PauseBoard 進來

    [Header("Pointer")]
    public GameObject rightPointer;    // 拖 RightPointer 進來

    [Header("Scene Names")]
    public string mainMenuSceneName = "root";
    public string level1SceneName = "Lv.1";
    public string level2SceneName = "Lv.2";
    public string level3SceneName = "Lv.3";

    private bool isPaused = false;

    void Start()
    {
        if (pauseBoard != null) pauseBoard.SetActive(false);
        if (rightPointer != null) rightPointer.SetActive(false); // 一開始不顯示雷射

        Time.timeScale = 1f;
    }

    void Update()
    {
        // B 鍵：Button.Two
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (pauseBoard != null) pauseBoard.SetActive(isPaused);
        if (rightPointer != null) rightPointer.SetActive(isPaused);

        Time.timeScale = isPaused ? 0f : 1f;
    }

    // ==== 給各按鈕用 ====
    public void OnClick_Resume()
    {
        Time.timeScale = 1f;
        var current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.name);
    }

    public void OnClick_ExitToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuSceneName);
    }

    public void OnClick_PlayLv1() { LoadLevel(level1SceneName); }
    public void OnClick_PlayLv2() { LoadLevel(level2SceneName); }
    public void OnClick_PlayLv3() { LoadLevel(level3SceneName); }

    private void LoadLevel(string sceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }
}
