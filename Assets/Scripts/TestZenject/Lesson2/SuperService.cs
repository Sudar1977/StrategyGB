using System.Collections;
using UnityEngine;

namespace Assets.Scripts.TestZenject
{
    public class SuperService : MonoBehaviour, IService
    {
        public void Test()
        {
            Debug.Log("SuperService");
        }
    }
}