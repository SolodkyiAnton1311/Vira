
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("Colors")] 
    [SerializeField] private Color whiteColor;
    [SerializeField] private Color blackColor;
    [Header(("UI"))]
    [SerializeField] private GameObject mainMenuUI;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private Text score;
    [SerializeField] private Text starText;

    private Camera _camera;

    private static UIController _instance;
    public static UIController Instance => _instance;

    private void Start()
    {
        _camera = Camera.main;
        UpdateStarShop(starText);
        if (PlayerPrefs.GetInt("BG",0) == 1)
        {
            _camera.backgroundColor = blackColor;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public void UpdateStarShop(Text starText)
    {
        starText.text = PlayerPrefs.GetInt("Star", 0).ToString();
    }

    public void ChangeBGColor()
    {
        if (_camera.backgroundColor == whiteColor)
        {
            PlayerPrefs.SetInt("BG",1);
            _camera.backgroundColor = blackColor;
            return;
        }
        PlayerPrefs.SetInt("BG",0);
        _camera.backgroundColor = whiteColor;
    }

    public void StartGame()
    {
        mainMenuUI.SetActive(false);
        gameUI.SetActive(true);
    }

    public void updateScore()
    {
        score.text = GameManager.Instance.score.ToString();
    }

    public void showGameOver()
    {
        gameOverUI.SetActive(true);
    }
}