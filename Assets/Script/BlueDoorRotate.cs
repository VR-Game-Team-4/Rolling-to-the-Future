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
        closedRot = transform.rotation;
        openRot = Quaternion.Euler(transform.eulerAngles + new Vector3(0, openAngle, 0));
    }

    private void Update()
    {
        // Listen for A button (Meta Quest)
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            globalIsOpen = !globalIsOpen; // Toggle for all doors
        }

        // Rotate toward target orientation
        if (globalIsOpen)
            transform.rotation = Quaternion.Slerp(transform.rotation, openRot, Time.deltaTime * speed);
        else
            transform.rotation = Quaternion.Slerp(transform.rotation, closedRot, Time.deltaTime * speed);
    }
}
