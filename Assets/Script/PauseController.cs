using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
  [Header("UI Root")]
  public GameObject pauseBoard;

  [Header("Pointer")]
  public GameObject rightPointer;

  private bool isPaused = false;

  private void Start()
  {
    pauseBoard.SetActive(false);
    rightPointer.SetActive(false);
  }

  void Update()
  {
    if (OVRInput.GetDown(OVRInput.Button.Two))
    {
      TogglePause();
    }
  }

  public void TogglePause()
  {
    isPaused = !isPaused;
    pauseBoard?.SetActive(isPaused);
    rightPointer?.SetActive(isPaused);
  }
}
