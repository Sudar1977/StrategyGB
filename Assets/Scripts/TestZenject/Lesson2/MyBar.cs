using System.Collections;
using UnityEngine;

namespace Assets.Scripts.TestZenject.Lesson2
{
    public class MyBar : MonoBehaviour
    {
        IService _service;

        public MyBar(IService service)
        {
            _service = service;
        }

        //public OneService _service;
        public void LogicService()
        {
            var foo = new MyFoo(_service);
        }
    }
}