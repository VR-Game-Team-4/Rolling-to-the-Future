using UnityEngine;

public class BlueStoneRotator : MonoBehaviour
{
    public float rotateAngle = 90f; // How much each child will rotate
    public float speed = 3f;        // Smooth rotation speed

    private Quaternion[] originalRotations;  // Default rotations
    private Quaternion[] targetRotations;    // Rotated target rotations

    private bool rotated = false;            // Current state

    private void Start()
    {
        int count = transform.childCount;

        originalRotations = new Quaternion[count];
        targetRotations = new Quaternion[count];

        // Store each child's localRotation as "closed"
        for (int i = 0; i < count; i++)
        {
            Transform child = transform.GetChild(i);

            originalRotations[i] = child.localRotation;
            targetRotations[i] = child.localRotation * Quaternion.Euler(0f, rotateAngle, 0f);
        }
    }

    private void Update()
    {
        // Toggle when A button is pressed
        if (OVRInput.GetDown(OVRInput.Button.One) || Input.GetKeyDown(KeyCode.Space))
        {
            rotated = !rotated;
        }

        // Smoothly rotate children toward their target pose
        RotateChildrenSmooth();
    }

    private void RotateChildrenSmooth()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);

            Quaternion target = rotated ? targetRotations[i] : originalRotations[i];

            child.localRotation = Quaternion.Slerp(
                child.localRotation,
                target,
                Time.deltaTime * speed
            );
        }
    }
}
