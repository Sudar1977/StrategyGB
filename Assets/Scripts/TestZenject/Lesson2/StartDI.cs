using System.Collections;
using UnityEngine;

namespace Assets.Scripts.TestZenject.Lesson2
{
    public class StartDI : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            var bar = new MyBar(new OneService());
            var bar2 = new MyBar(new TwoService());
        }

    }
}