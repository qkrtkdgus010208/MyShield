using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] GameObject square;
    [SerializeField] Text timeText;
    [SerializeField] GameObject endPanel;
    [SerializeField] Text nowScore;

    private float time;
    private bool isPlay;

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
        Time.timeScale = 0.0f;
        nowScore.text = time.ToString("F2");
        endPanel.SetActive(true);
    }
}
