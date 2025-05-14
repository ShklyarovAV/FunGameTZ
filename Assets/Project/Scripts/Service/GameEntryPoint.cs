using UnityEngine;
using Zenject;

public class GameEntryPoint : MonoBehaviour
{
    private LevelManager _levelManager;
    private UIManager _uiManager;

    [Inject]
    public void Construct(LevelManager levelManager,
                          UIManager uiManager)
    {
        _levelManager = levelManager;
        _uiManager = uiManager;
    }

    private void Start()
    {
        _uiManager.OpenMenuView();
    }
}
