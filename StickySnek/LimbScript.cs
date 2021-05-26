using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace StickySnek
{
    public class LimbScript : MonoBehaviour
    {
        private GameObject limbObject;
        private int saveId;
        private int side = 1;
        
        private void Start()
        {
            limbObject = this.gameObject;
            saveId = limbObject.GetComponent<tosaveitemscript>().idInSave;
            Random.seed = saveId;
            if (Random.value <= 0.5f) side = -1;
            var localScale = limbObject.transform.localScale;
            localScale = new Vector3(localScale.x * side, localScale.y, localScale.z);
            limbObject.transform.localScale = localScale;
        }
    }
}