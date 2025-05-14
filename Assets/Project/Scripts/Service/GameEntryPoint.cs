using UnityEngine;
using Zenject;

public class GameEntryPoint : MonoBehaviour
{
    private LevelManager _levelManager;

    [Inject]
    public void Construct(LevelManager levelManager)
    {
        _levelManager = levelManager;
    }

    private void Start()
    {
        _levelManager.Level.StartLevel();
    }
}
