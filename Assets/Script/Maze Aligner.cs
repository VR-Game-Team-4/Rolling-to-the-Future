using UnityEngine;

public class StretchAlongZ : MonoBehaviour
{
  public Transform leftHand;
  public Transform rightHand;

  [Header("模型原始 Z 軸長度（實際世界長度）")]
  public float originalZLength = 1f;

  private Vector3 originalScale;

  void Start()
  {
    // 記錄最初 scale，用來等比例放大
    originalScale = transform.localScale;
  }

  void Update()
  {
    if (!leftHand || !rightHand) return;

    // 1. 放在兩手中點
    transform.position = (leftHand.position + rightHand.position) * 0.5f;

    // 2. 讓 local +Z 對準右手方向
    Vector3 direction = (leftHand.position - rightHand.position).normalized;
    transform.rotation = Quaternion.LookRotation(direction, Vector3.up);

    // 3. 計算兩手實際距離
    float handDistance = Vector3.Distance(leftHand.position, rightHand.position);

    // 4. 計算等比例縮放因子
    float scaleFactor = handDistance / originalZLength;

    // 5. 等比例縮放所有軸（保持長寬高比例）
    transform.localScale = originalScale * scaleFactor;
  }
}
