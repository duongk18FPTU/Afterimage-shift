using UnityEngine;
using UnityEngine.UI; // Thư viện cho Slider
using TMPro; // Thư viện cho TextMeshPro

public class TimeManager : MonoBehaviour
{
    [Header("References")]
    public PlayerMovement player;
    public GameObject ghostPrefab;
    public Slider timeSlider; // Kéo TimeSlider vào đây
    public TextMeshProUGUI timerText; // Kéo TimerText vào đây

    [Header("Settings")]
    public float roundTime = 20f;

    private float currentMaxTime;
    private float timer;
    private Vector3 startPosition;

    void Start()
    {
        currentMaxTime = roundTime;
        timer = currentMaxTime;
        startPosition = player.transform.position;

        // Thiết lập giá trị đầu cho UI
        if (timeSlider != null) timeSlider.value = 1f;
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            UpdateUI();
        }
        else
        {
            StartNewRound();
        }
    }

    void UpdateUI()
    {
        // Cập nhật thanh Slider (chạy lùi từ 1 về 0)
        if (timeSlider != null)
        {
            timeSlider.value = timer / currentMaxTime;
        }

        // Cập nhật chữ số (hiện 1 chữ số thập phân cho kịch tính)
        if (timerText != null)
        {
            timerText.text = timer.ToString("F1") + "s";

            // Đổi màu chữ sang đỏ khi còn dưới 5 giây
            if (timer < 5f) timerText.color = Color.red;
            else timerText.color = Color.white;
        }
    }

    void StartNewRound()
    {
        // CHỐT: Xóa bóng cũ, chỉ giữ 1 bóng duy nhất
        GameObject[] oldGhosts = GameObject.FindGameObjectsWithTag("Ghost");
        foreach (GameObject g in oldGhosts) Destroy(g);

        if (player.positionHistory.Count > 0)
        {
            GameObject newGhost = Instantiate(ghostPrefab, player.positionHistory[0], Quaternion.identity);
            newGhost.transform.localScale = player.transform.localScale;
            newGhost.tag = "Ghost";
            newGhost.GetComponent<GhostController>().SetData(new System.Collections.Generic.List<Vector3>(player.positionHistory));
        }

        // Reset lại các thông số
        timer = roundTime;
        currentMaxTime = roundTime;
        player.transform.position = startPosition;
        player.positionHistory.Clear();

        // Reset vận tốc vật lý để tránh bị trượt khi hồi sinh
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        if (rb != null) rb.linearVelocity = Vector2.zero;
    }

    // Trong TimeManager.cs
    public void AddExtraTime(float extraSeconds)
    {
        timer += extraSeconds;
        // Làm cho thanh Slider cũng dài ra tương ứng để người chơi thấy rõ
        currentMaxTime += extraSeconds;
        Debug.Log("Đã nhặt pin! Thời gian còn lại: " + timer);
    }
}