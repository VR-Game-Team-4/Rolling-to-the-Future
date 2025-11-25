using UnityEngine;

public class SimpleDoor : MonoBehaviour
{
    [Header("門的動畫")]
    public Animation doorAnimation;                 // Inspector 指到 Animation component
    public string openAnimName = "Door_Open";       // 開門動畫 clip 名稱
    public string closeAnimName = "Door_Close";     // 關門動畫 clip 名稱

    [Header("門的碰撞器 (會擋住球/玩家的那個)")]
    public Collider doorCollider;                   // 可以在 Inspector 指定，或讓程式自動抓

    private bool isOpen = false;

    void Start()
    {
        // 如果沒在 Inspector 指定，就自動抓同一顆物件上的 Collider
        if (doorCollider == null)
        {
            doorCollider = GetComponent<Collider>();
        }

        // 一開始門是關著的 → 要有碰撞
        if (doorCollider != null)
        {
            doorCollider.enabled = true;
        }
    }

    void Update()
    {
        // A 鍵：OVRInput.Button.One，這裡用右手控制器
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            if (!isOpen)
            {
                // 播放開門動畫
                if (doorAnimation != null)
                    doorAnimation.Play(openAnimName);

                isOpen = true;

                // 門打開 → 碰撞關掉，東西可以穿過
                if (doorCollider != null)
                    doorCollider.enabled = false;
            }
            else
            {
                // 播放關門動畫
                if (doorAnimation != null)
                    doorAnimation.Play(closeAnimName);

                isOpen = false;

                // 門關起來 → 碰撞打開，擋住球/玩家
                if (doorCollider != null)
                    doorCollider.enabled = true;
            }
        }
    }
}
