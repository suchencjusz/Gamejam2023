using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomType : MonoBehaviour
{
    public int type; // 1 --> LR, 2 --> LRB, 3 --> LRT, 4 --> LRBT

    public void RoomDestruction() {
        Destroy(gameObject);
    }
}
