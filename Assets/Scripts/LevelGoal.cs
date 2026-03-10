using UnityEngine;
using UnityEngine.SceneManagement; // Bắt buộc phải có để chuyển màn

public class LevelGoal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Chỉ cho phép Player (người thật) kích hoạt chuyển màn
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Chúc mừng! Chuyển sang màn tiếp theo.");
            LoadNextLevel();
        }
    }

    void LoadNextLevel()
    {
        // Lấy chỉ số (index) của màn hiện tại và cộng thêm 1
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        // Kiểm tra xem có màn tiếp theo trong Build Settings không
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("Bạn đã phá đảo game! Không còn màn tiếp theo.");
            // Có thể quay về màn hình chính (Menu) nếu muốn
            // SceneManager.LoadScene(0); 
        }
    }
}