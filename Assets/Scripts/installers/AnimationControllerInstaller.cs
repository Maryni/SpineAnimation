using UnityEngine;
using Zenject;

public class AnimationControllerInstaller : MonoInstaller
{
    [SerializeField] private AnimationController animationController;
    public override void InstallBindings()
    {
        Container.BindInstance(animationController);
    }
}