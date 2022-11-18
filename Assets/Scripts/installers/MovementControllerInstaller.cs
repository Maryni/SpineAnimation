using UnityEngine;
using Zenject;

public class MovementControllerInstaller : MonoInstaller
{
    [SerializeField] private MovementController movementController;
    public override void InstallBindings()
    {
        Container.BindInstance(movementController);
    }
}