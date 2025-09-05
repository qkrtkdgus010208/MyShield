using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] GameObject square;
    [SerializeField] Text timeText;
    [SerializeField] GameObject endPanel;
    [SerializeField] Text nowScore;
    [SerializeField] Text bestScore;
    [SerializeField] Animator anim;

    private float time;
    private bool isPlay;
    private string key = "bestScore";

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        isPlay = true;
        Time.timeScale = 1.0f;

        InvokeRepeating("MakeSquare", 0f, 1f);
    }

    private void Update()
    {
        if (isPlay)
        {
            time += Time.deltaTime;
            timeText.text = time.ToString("F2");
        }
    }

    private void MakeSquare()
    {
        Instantiate(square);
    }

    public void GameOver()
    {
        isPlay = false;
        anim.SetBool("isDie", true);
        Invoke("TimeStop", 0.5f);
        nowScore.text = time.ToString("F2");

        UpdateBestScore();

        endPanel.SetActive(true);
    }

    private void UpdateBestScore()
    {
        // 최고 점수가 있다면
        if (PlayerPrefs.HasKey(key))
        {
            float best = PlayerPrefs.GetFloat(key);

            // 최고 점수 < 현재 점수
            if (best < time)
            {
                // 현재 점수를 최고 점수에 저장
                PlayerPrefs.SetFloat(key, time);
                bestScore.text = time.ToString("F2");
            }
            else
            {
                bestScore.text = best.ToString("F2");
            }
        }
        else
        {
            PlayerPrefs.SetFloat(key, time);
            bestScore.text = time.ToString("F2");
        }
    }

    private void TimeStop()
    {
        Time.timeScale = 0.0f;
    }
}
