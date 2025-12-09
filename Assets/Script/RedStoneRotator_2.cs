using UnityEngine;

public class StoneGroupRotator2 : MonoBehaviour
{
    public float openAngle = 90f;
    public float speed = 3f;

    private Quaternion closedRot;
    private Quaternion openRot;
    private bool isOpen = false;

    private void Start()
    {
        closedRot = transform.localRotation;
        openRot = closedRot * Quaternion.Euler(0f, openAngle, 0f);
    }

    public void SetOpen(bool value)
    {
        isOpen = value;
    }

    // 如果想用切換可以加這個（可選）
    public void Toggle()
    {
        isOpen = !isOpen;
    }

    private void Update()
    {
        Quaternion target = isOpen ? openRot : closedRot;
        if (OVRInput.GetDown(OVRInput.Button.Three))
        {
            Toggle();
        }
        transform.localRotation = Quaternion.Slerp(
            transform.localRotation,
            target,
            Time.deltaTime * speed
        );
    }
}
