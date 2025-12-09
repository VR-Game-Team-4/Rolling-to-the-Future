using UnityEngine;

public class StretchAndRoll : MonoBehaviour
{
    public Transform leftHand;
    public Transform rightHand;

    [Header("右手旋轉 offset（可在 Inspector 調整）")]
    public Transform rightHandRotationOffset;

    [Header("Original Z Length")]
    public float originalZ;

    private Quaternion baseRotation;
    private Vector3 baseScale;

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

        // LookRotation 得到「Z 軸對準兩手方向」的旋轉
        Quaternion lookRot = Quaternion.LookRotation(zDir, Vector3.up);


        // --- Step 2: 取得右手的 roll ---
        // 我們想要右手的 "local axes" 其中一個軸投影到 lookRot 的空間中
        Quaternion rightRot = rightHand.rotation;

        if (rightHandRotationOffset)
            rightRot *= rightHandRotationOffset.localRotation;

        // 取得右手在對齊後空間中的向右方向
        Vector3 handRight = lookRot * Vector3.right;
        Vector3 wristRight = rightRot * Vector3.right;

        // 計算 roll 角（繞 Z 軸）
        float rollAngle = Vector3.SignedAngle(handRight, wristRight, zDir);


        // --- Step 3: 套用 roll ---
        Quaternion rollRot = Quaternion.AngleAxis(rollAngle, zDir);

        transform.rotation = rollRot * lookRot;
        transform.position = rightHand.position;
        float scalFactor = Vector3.Distance(rightHand.position, leftHand.position) / originalZ;
        transform.localScale = baseScale * scalFactor;
    }
}