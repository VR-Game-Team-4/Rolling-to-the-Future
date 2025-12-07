using UnityEngine;

public class BlueDoor : MonoBehaviour
{
    public float openAngle = 90f;
    public float speed = 3f;

    private Quaternion closedRot;
    private Quaternion openRot;

    private static bool globalIsOpen = false;   // Shared by ALL door scripts

    private void Start()
    {
        // 用 localRotation 當關門姿勢
        closedRot = transform.localRotation;
        // 在關門姿勢的基礎上，繞「自己 Y 軸」多轉 openAngle 度
        openRot = closedRot * Quaternion.Euler(0f, openAngle, 0f);
    }

    private void Update()
    {
        // Listen for A button (Meta Quest)
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            globalIsOpen = !globalIsOpen; // Toggle for all doors
        }

        // 目標旋轉（只在關 / 開兩個姿勢之間插值）
        Quaternion target = globalIsOpen ? openRot : closedRot;

        // Slerp 到目標，改用 localRotation，避免整個世界的旋轉影響
        transform.localRotation = Quaternion.Slerp(
            transform.localRotation,
            target,
            Time.deltaTime * speed
        );
    }
}
