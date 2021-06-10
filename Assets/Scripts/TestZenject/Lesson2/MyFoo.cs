using System.Collections;
using UnityEngine;

namespace Assets.Scripts.TestZenject.Lesson2
{
    public class MyFoo : MonoBehaviour
    {
        IService _service;

        public MyFoo(IService service)
        {
            _service = service;
        }

        //public OneService _service;
        public void LogicService()
        {
            _service.Test();
        }

    }
}