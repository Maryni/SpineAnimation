using UnityEngine;
using Zenject;

public class UIControllerInstaller : MonoInstaller
{
    [SerializeField] private UIController uiController;
    public override void InstallBindings()
    {
        Container.BindInstance(uiController);
    }
}