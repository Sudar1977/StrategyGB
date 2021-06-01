using System;
using System.Reflection;

namespace Utils
{

    public static class AssetsInjector
    {
        public static T Inject<T>(this AssetContext context, T target)
        {
            var targetType = target.GetType();
            var fields = targetType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (var field in fields)
            {
                //var injectAssetAttribute = field.GetCustomAttributes(typeof(InjectAssetAttribute)) as InjectAssetAttribute;
                if (field.GetCustomAttribute(typeof(InjectAssetAttribute)) is InjectAssetAttribute injectAssetAttribute)
                {
                    var prefab = context.getAsset(injectAssetAttribute.AssetName);
                    field.SetValue(target, prefab);
                }
            }
            return target;
        }
    }




    public static class AssetsInjectorMet
    {
        private static readonly Type _injectAssetAttributeType = typeof(InjectAssetAttribute);

        public static T InjectMet<T>(this AssetContext  context, T target)
        {
            var targetType = target.GetType();
            while (targetType != null)
            {
                var allFields = targetType.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

                for (int i = 0; i < allFields.Length; i++)
                {
                    var fieldInfo = allFields[i];
                    var injectAssetAttribute = fieldInfo.GetCustomAttribute(_injectAssetAttributeType) as InjectAssetAttribute;
                    if (injectAssetAttribute == null)
                    {
                        continue;
                    }
                    var objectToInject = context.GetObjectOfType(fieldInfo.FieldType, injectAssetAttribute.AssetName);
                    fieldInfo.SetValue(target, objectToInject);
                }

                targetType = targetType.BaseType;
            }

            return target;
        }
    }

}