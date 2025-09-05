using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject square;
    [SerializeField] Text timeText;

    private float time;

    private void Start()
    {
        InvokeRepeating("MakeSquare", 0f, 1f);
    }

    private void Update()
    {
        time += Time.deltaTime;
        timeText.text = time.ToString("F2");
    }

    private void MakeSquare()
    {
        Instantiate(square);
    }
}
