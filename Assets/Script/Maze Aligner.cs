using UnityEngine;

public class StretchAndRoll : MonoBehaviour
{
    public Transform leftHand;
    public Transform rightHand;

    [Header("右手旋轉 offset（可在 Inspector 調整）")]
    public Transform rightHandRotationOffset;

    [Header("offset")]
    public Vector3 offset;

    [Header("Original Z Length")]
    public float originalZ;

    private Quaternion baseRotation;
    private Vector3 baseScale;

    public void LoadLevel()
    {
      offset.x = 0;
    }

    public void UnloadLevel()
    {
      offset.x = 100;
    }

    void Start()
    {
        // 記錄原始 localRotation
        baseRotation = transform.localRotation;
        baseScale = transform.localScale;
    }

    void Update()
    {
        if (!leftHand || !rightHand) return;

        // --- Step 1: 設定 Z 軸方向 ---
        Vector3 zDir = (leftHand.position - rightHand.position).normalized;
        Quaternion lookRot = Quaternion.LookRotation(zDir, Vector3.up);

        // --- Step 2: 取得右手的 roll ---
        Quaternion rightRot = rightHand.rotation;
        if (rightHandRotationOffset)
            rightRot *= rightHandRotationOffset.localRotation;

        Vector3 handRight = lookRot * Vector3.right;
        Vector3 wristRight = rightRot * Vector3.right;

        float rollAngle = Vector3.SignedAngle(handRight, wristRight, zDir);

        // --- Step 3: 套用 roll ---
        Quaternion rollRot = Quaternion.AngleAxis(rollAngle, zDir);

        // 先決定旋轉
        transform.rotation = rollRot * lookRot;

        // ✅ 將 offset 視為「local 座標」，轉成世界偏移
        // offset.x = 沿著物件 local X（垂直兩手連線）偏移
        // offset.y = 沿著物件 local Y 偏移
        // offset.z = 沿著物件 local Z（兩手連線方向）偏移
        Vector3 worldOffset = transform.rotation * offset;
        transform.position = rightHand.position + worldOffset;

        // 縮放
        float scalFactor = Vector3.Distance(rightHand.position, leftHand.position) / originalZ;
        transform.localScale = baseScale * scalFactor;
    }

}