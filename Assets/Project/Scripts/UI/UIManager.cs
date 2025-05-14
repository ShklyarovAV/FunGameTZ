using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private MenuView _menuView;
    [SerializeField] private WinView _winView;
    [SerializeField] private LoseView _loseView;
    [SerializeField] private GameView _gameView;

    public MenuView MenuView => _menuView;
    public WinView WinView => _winView;
    public GameView GameView => _gameView;
    public LoseView LoseView => _loseView;

    private ViewBase _curView;

    public void OpenMenuView()
    {
        ChangeView(_menuView);
    }

    public void OpenGameView()
    {
        ChangeView(_gameView);
    }

    public void OpenLoseView()
    {
        ChangeView(_loseView);
    }

    public void OpenWinView()
    {
        ChangeView(_winView);
    }

    private void ChangeView(ViewBase newView)
    {
        if (_curView != null)
        {
            _curView.Hide();
        }

        _curView = newView;
        _curView.Show();
    }

    private void OnEnable()
    {
        _menuView.OnStartClick += OpenGameView;
        _loseView.OnContinueClick += OpenGameView;
        _winView.OnContinueClick += OpenGameView;
    }

    private void OnDisable()
    {
        _menuView.OnStartClick -= OpenGameView;
        _loseView.OnContinueClick -= OpenGameView;
        _winView.OnContinueClick -= OpenGameView;
    }
}
