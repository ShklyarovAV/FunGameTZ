using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private MenuView _menuView;
    [SerializeField] private WinView _winView;
    [SerializeField] private LoseView _loseView;
    [SerializeField] private GameView _gameView;

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
}
