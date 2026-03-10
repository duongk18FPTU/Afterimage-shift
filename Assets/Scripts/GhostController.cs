using UnityEngine;
using System.Collections.Generic;

public class GhostController : MonoBehaviour
{
    private List<Vector3> recordedPositions;
    private int currentFrame = 0;

    public void SetData(List<Vector3> data)
    {
        recordedPositions = new List<Vector3>(data);
        currentFrame = 0;
    }

    void FixedUpdate()
    {
        if (recordedPositions != null && currentFrame < recordedPositions.Count)
        {
            // Di chuyển Ghost đến vị trí đã lưu trong quá khứ
            transform.position = recordedPositions[currentFrame];
            currentFrame++;
        }
    }
}