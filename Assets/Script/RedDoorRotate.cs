using UnityEngine;

public class RedDoor : MonoBehaviour
{
    public float openAngle = 90f;
    public float speed = 3f;

    private Quaternion closedRot;
    private Quaternion openRot;

    private static bool globalIsOpen = false;   // Shared by ALL door scripts

    private void Start()
    {
        closedRot = transform.rotation;
        openRot = Quaternion.Euler(transform.eulerAngles + new Vector3(0, openAngle, 0));
    }

    private void Update()
    {
        // Listen for X button on left controller
        if (OVRInput.GetDown(OVRInput.Button.Three))
        {
            globalIsOpen = !globalIsOpen;
        }

        // Rotate toward target rotation
        if (globalIsOpen)
            transform.rotation = Quaternion.Slerp(transform.rotation, openRot, Time.deltaTime * speed);
        else
            transform.rotation = Quaternion.Slerp(transform.rotation, closedRot, Time.deltaTime * speed);
    }
}
