using UnityEngine;

public class TriggerMechanism : MonoBehaviour
{
    public GameObject door; // Cánh cửa sẽ mở
    private int occupantCount = 0; // Đếm số người (Player hoặc Ghost) đang đứng trên nút

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra nếu là Player hoặc Ghost chạm vào nút
        if (collision.CompareTag("Player") || collision.CompareTag("Ghost"))
        {
            occupantCount++;
            UpdateDoorState();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Ghost"))
        {
            occupantCount--;
            UpdateDoorState();
        }
    }

    void UpdateDoorState()
    {
        if (occupantCount > 0)
        {
            door.SetActive(false); // Mở cửa (ẩn cửa đi)
            Debug.Log("Cua mo!");
        }
        else
        {
            door.SetActive(true); // Đóng cửa
        }
    }
}