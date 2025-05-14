using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private UIManager _uiManager;

    public override void InstallBindings()
    {
        Container.Bind<LevelManager>().FromInstance(_levelManager).AsSingle();
        Container.Bind<UIManager>().FromInstance(_uiManager).AsSingle();
    }
}
