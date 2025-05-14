using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameView : ViewBase
{
    public UnityAction OnRefreshClick;

    [SerializeField] private Button _refreshButton;

    private void ClickRefresh()
    {
        OnRefreshClick?.Invoke();
    }

    private void OnEnable()
    {
        _refreshButton.onClick.AddListener(ClickRefresh);
    }

    private void OnDisable()
    {
        _refreshButton.onClick.RemoveListener(ClickRefresh);
    }
}
