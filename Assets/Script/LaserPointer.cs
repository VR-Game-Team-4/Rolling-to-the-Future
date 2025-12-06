using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaserPointer : MonoBehaviour
{
    public float maxLength = 10f;          // 甮絬程
    public LayerMask hitLayers = ~0;      // 璶ゴㄇ layer箇砞ゴ场
    public Transform endDot;              // 沧翴翴单单 Inspector 

    private LineRenderer lr;

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 2;
        lr.useWorldSpace = true;
        lr.startWidth = 0.01f;
        lr.endWidth = 0.01f;
    }

    void Update()
    {
        Vector3 start = transform.position;
        Vector3 end = start + transform.forward * maxLength;

        // ノ Physics.Raycast ∕﹚絬沧翴
        RaycastHit hit;
        if (Physics.Raycast(start, transform.forward, out hit, maxLength, hitLayers))
        {
            end = hit.point;
        }

        lr.SetPosition(0, start);
        lr.SetPosition(1, end);

        // 狦Τ砞﹚ endDot碞рウ簿沧翴
        if (endDot != null)
        {
            endDot.position = end;
            endDot.gameObject.SetActive(true);
        }
    }
}
