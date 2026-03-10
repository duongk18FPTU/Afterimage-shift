using UnityEngine;

public class TimePowerUp : MonoBehaviour
{
    public float amount = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra xem đối tượng va chạm có Tag là Player không
        if (collision.CompareTag("Player"))
        {
            // Tìm script TimeManager trong Scene
            TimeManager tm = Object.FindFirstObjectByType<TimeManager>();

            if (tm != null)
            {
                tm.AddExtraTime(amount);
                Debug.Log("Đã nhặt pin! Cộng thêm " + amount + " giây.");
                Destroy(gameObject); // Xóa viên Pin sau khi nhặt
            }
            else
            {
                Debug.LogError("Không tìm thấy TimeManager trong màn chơi này!");
            }
        }
    }
}