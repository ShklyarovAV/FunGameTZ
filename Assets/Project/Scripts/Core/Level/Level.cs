using UnityEngine;
using Zenject;

public class Level : MonoBehaviour
{
    [SerializeField] private FigureController _figureController;
    [SerializeField] private SpotController _spotController;
    [SerializeField] private InputHandler _inputHandler;

    private UIManager _uiManager;

    [Inject]
    public void Construct(UIManager uIManager)
    {
        _uiManager = uIManager;
    }

    public FigureController FigureController => _figureController;
    public SpotController SpotController => _spotController;

    public void StartLevel()
    {
        _figureController.FigureSpawner.SpawnFigures();
        _inputHandler.SetActive(true);
    }

    public void LoseLevel()
    {
        ClearLevel();
        _uiManager.OpenLoseView();
    }

    public void WinLevel()
    {
        ClearLevel();
        _uiManager.OpenWinView();
    }

    private void ClearLevel()
    {
        _inputHandler.SetActive(false);
        _figureController.Clear();
        _spotController.Clear();
    }

    private void OnEnable()
    {
        _uiManager.MenuView.OnStartClick += StartLevel;
        _uiManager.LoseView.OnContinueClick += StartLevel;
        _uiManager.WinView.OnContinueClick += StartLevel;
        _uiManager.GameView.OnRefreshClick += _figureController.FigureSpawner.RefreshFigures;
    }

    private void OnDisable()
    {
        _uiManager.MenuView.OnStartClick -= StartLevel;
        _uiManager.LoseView.OnContinueClick -= StartLevel;
        _uiManager.WinView.OnContinueClick -= StartLevel;
        _uiManager.GameView.OnRefreshClick -= _figureController.FigureSpawner.RefreshFigures;
    }
}
