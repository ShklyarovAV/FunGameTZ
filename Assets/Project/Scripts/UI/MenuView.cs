using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MenuView : ViewBase
{
    public UnityAction OnStartClick;

    [SerializeField] private Button _startButton;

    private void ClickStart()
    {
        OnStartClick?.Invoke();
    }

    private void OnEnable()
    {
        _startButton.onClick.AddListener(ClickStart);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(ClickStart);
    }
}
