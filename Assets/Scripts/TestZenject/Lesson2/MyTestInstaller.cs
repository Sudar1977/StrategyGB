using UnityEngine;
using Zenject;

public class MyTestInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<string>().FromInstance("Hellow world");
        Container.Bind<Test>().AsSingle().NonLazy();
    }
}

public class Test
{
    public Test(string message)
    {
        Debug.Log(message);
    }
}