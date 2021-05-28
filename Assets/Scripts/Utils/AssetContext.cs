using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Utils
{
    [CreateAssetMenu(fileName = nameof(AssetContext), menuName = "Strategy/"+ nameof(AssetContext))]
    public class AssetContext : ScriptableObject
    {
        [SerializeField] private GameObject[] _assets;
        //[SerializeField] public GameObject[] _assets;

        public GameObject getAsset(string assetName)
        {
            return _assets.FirstOrDefault(asset => asset.gameObject.name == assetName);
        }
        //по методичке
        public Object GetObjectOfType(Type targetType, string targetName = null)
        {
            for (int i = 0; i < _assets.Length; i++)
            {
                var obj = _assets[i];
                if (obj.GetType().IsAssignableFrom(targetType))
                {
                    if (targetName == null || obj.name == targetName)
                    {
                        return obj;
                    }
                }
            }
            return null;
        }



    }
}