using UnityEngine;

public class BRDoorController : MonoBehaviour
{
    [Header("要被控制的門（拖 BlueDoor 腳本進來）")]
    public BlueDoor[] blueDoors;   // 藍門們
    public RedDoor[] redDoors;    // 紅門們

    // 目前兩邊的開關狀態
    private bool blueOpen = false;
    private bool redOpen = false;

    // 給「藍方」用的開關
    public void ToggleBlue()
    {
        blueOpen = !blueOpen;
        Debug.Log("[BRDoorController] Toggle BLUE doors, isOpen = " + blueOpen);

        foreach (var d in blueDoors)
        {
            if (d != null)
                d.SetOpen(blueOpen);
        }
    }

    // 給「紅方」用的開關
    public void ToggleRed()
    {
        redOpen = !redOpen;
        Debug.Log("[BRDoorController] Toggle RED doors, isOpen = " + redOpen);

        foreach (var d in redDoors)
        {
            if (d != null)
                d.SetOpen(redOpen);
        }
    }
}
