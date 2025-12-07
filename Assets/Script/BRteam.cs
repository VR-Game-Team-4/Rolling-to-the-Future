using UnityEngine;

public enum PlayerRole
{
    Blue,
    Red
}

public class PlayerDoorInput : MonoBehaviour
{
    public PlayerRole role = PlayerRole.Blue;      // 這台頭盔是藍還是紅
    public BRDoorController doorController;        // 在 Inspector 把場景裡的 BRDoorController 拖進來

    void Update()
    {
        // 這台頭盔自己的 A 鍵（＋鍵盤 A 方便在 Editor 測試）
        bool pressed =
            OVRInput.GetDown(OVRInput.Button.One) ||
            Input.GetKeyDown(KeyCode.A);

        if (!pressed || doorController == null)
            return;

        if (role == PlayerRole.Blue)
        {
            doorController.ToggleBlue();
        }
        else // PlayerRole.Red
        {
            doorController.ToggleRed();
        }
    }
}
