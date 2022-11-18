using UnityEngine;
using Zenject;

public class PlayerTouchMovementInstaller : MonoInstaller
{
    [SerializeField] private PlayerTouchMovement playerTouchMovement;
    public override void InstallBindings()
    {
        Container.BindInstance(playerTouchMovement);
    }
}