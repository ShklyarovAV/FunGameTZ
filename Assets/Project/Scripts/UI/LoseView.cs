using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LoseView : ViewBase
{
    public UnityAction OnContinueClick;

    [SerializeField] private Button _continueButton;

    private void ClickContinue()
    {
        OnContinueClick?.Invoke();
    }

    private void OnEnable()
    {
        _continueButton.onClick.AddListener(ClickContinue);
    }

    private void OnDisable()
    {
        _continueButton.onClick.RemoveListener(ClickContinue);
    }
}
