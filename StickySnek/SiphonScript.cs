using System;
using System.Linq;
using UnityEngine;

namespace StickySnek
{
    public class SiphonScript : MonoBehaviour
    {
        private GameObject siphonObject;

        private void Start()
        {
            siphonObject = this.gameObject;
        }
    }
}