using UnityEngine;
using Zenject;

public class InputControllerInstaller : MonoInstaller
{
    [SerializeField] private InputController inputController;
    public override void InstallBindings()
    {
        Container.BindInstance(inputController);
    }
}