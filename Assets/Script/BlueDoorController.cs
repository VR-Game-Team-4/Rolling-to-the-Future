using UnityEngine;

public class BlueDoorController : MonoBehaviour
{
    // 在 Inspector 裡，把所有要一起開關的門拖進來
    public BlueDoor[] doors;

    private bool isOpen = false;   // 目前全域開關狀態

    private void Update()
    {
        // 支援 Quest A 鍵 ＋ 鍵盤 A（在 Editor 測試會用到）
        bool pressed =
            OVRInput.GetDown(OVRInput.Button.One) ||
            Input.GetKeyDown(KeyCode.A);

        if (pressed)
        {
            isOpen = !isOpen;
            Debug.Log("[BlueDoorController] Toggle doors, isOpen = " + isOpen);

            // 把狀態套用到每一扇門
            foreach (var door in doors)
            {
                if (door != null)
                    door.SetOpen(isOpen);
            }
        }
    }
}
