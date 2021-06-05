using Abstractions;
using UnityEngine;
using Utils;
using Zenject;
namespace InputSystem.UI.Model
{
    public class ModelInstaller : MonoInstaller
    {
        [SerializeField] private Vector3Value _currentGroundPosition;
        [SerializeField] private AssetContext _context;
        public override void InstallBindings()
        {
            Container.Bind<AssetContext>().FromInstance(_context).AsSingle();  
            
            Container.Bind<CommandCreatorBase<IProduceUnitEllenCommand>>().To<ProduceUnitElenCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IProduceUnitChomperCommand>>().To<ProduceUnitChopmperCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IMoveCommand>>().To<MoveCommandCreator>().AsTransient();
            
            Container.Bind<ButtonPanel>().AsTransient();
            Container.Bind<Vector3Value>().FromInstance(_currentGroundPosition).AsSingle();



        }
    }
}