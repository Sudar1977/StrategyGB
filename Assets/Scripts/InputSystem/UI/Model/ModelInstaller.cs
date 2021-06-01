using UnityEngine;
using Utils;
using Zenject;
namespace InputSystem.UI.Model
{
    public class ModelInstaller : MonoInstallerBase
    {
        [SerializeField] private AssetContext _context;
        public override void InstallBindings()
        {
            Container.Bind<AssetContext>().FromInstance(_context).AsSingle();
        }
    }
}