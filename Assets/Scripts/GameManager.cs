using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject square;

    private void Start()
    {
        InvokeRepeating("MakeSquare", 0f, 1f);
    }

    private void MakeSquare()
    {
        Instantiate(square);
    }
}
