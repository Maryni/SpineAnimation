using UnityEngine;
using Zenject;

public class PortalInstaller : MonoInstaller
{
    [SerializeField] private Portal portal;
    public override void InstallBindings()
    {
        Container.BindInstance(portal);
    }
}