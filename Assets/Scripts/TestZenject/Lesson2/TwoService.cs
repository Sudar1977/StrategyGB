using System.Collections;
using UnityEngine;

namespace Assets.Scripts.TestZenject
{
    public class TwoService : MonoBehaviour, IService
    {
        public void Test()
        {
            Debug.Log("TwoService");
        }
    }
}