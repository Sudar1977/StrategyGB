using System.Collections;
using UnityEngine;

namespace Assets.Scripts.TestZenject
{
    public class OneService : MonoBehaviour, IService
    {
        public void Test()
        {
            Debug.Log("OneService");
        }
    }
}