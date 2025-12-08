using UnityEngine;

public class SpringBounce : MonoBehaviour
{
    public float bounceSpeed = 10f;    // �u�_�Ӫ��t��

    private void OnCollisionEnter(Collision collision)
    {
        // �u����w Tag ������ͮġ]�Ҧp Ball�^
        if (!collision.gameObject.CompareTag("Ball"))
            return;

        Rigidbody rb = collision.rigidbody;
        if (rb == null) return;

        // ������y�� y ��V�t�׳]���V�W�]�T�w�j�p�^
        Vector3 v = rb.linearVelocity;
        if (v.y < 0f) v.y = 0f;        // �p�G���b���U���A���⩹�U���t�ײM��
        v.y = bounceSpeed;             // �Τ@�]���V�W�t��
        rb.linearVelocity = v;
    }
}
