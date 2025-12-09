using UnityEngine;

public class BlueDoor : MonoBehaviour
{
    public float openAngle = 90f;   // 這扇門要打開幾度（可以在 Inspector 調）
    public float speed = 3f;       // 旋轉速度

    private Quaternion closedRot;  // 關門時的旋轉
    private Quaternion openRot;    // 開門時的旋轉
    private bool isOpen = false;   // 這一扇門目前是不是開的

    private void Start()
    {
        // 用「自己的 localRotation」當關門姿勢
        closedRot = transform.localRotation;

        // 在關門姿勢的基礎上，繞自己的 Y 軸旋轉 openAngle 度，當作開門姿勢
        openRot = closedRot * Quaternion.Euler(0f, openAngle, 0f);
    }

    // 給外部呼叫：設定這扇門要不要開
    public void SetOpen(bool value)
    {
        isOpen = value;
    }

    private void Update()
    {
    if (OVRInput.GetDown(OVRInput.Button.One)) isOpen = !isOpen;
        // 目標姿勢：開門 or 關門
        Quaternion target = isOpen ? openRot : closedRot;

        // 在目前 localRotation 與目標之間插值
        transform.localRotation = Quaternion.Slerp(
            transform.localRotation,
            target,
            Time.deltaTime * speed
        );
    }
}
