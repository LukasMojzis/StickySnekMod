using System;
using UnityEngine;

namespace StickySnek
{
    public class BunnyScript : MonoBehaviour
    {
        private GameObject bunnyObject;

        private void Start()
        {
            bunnyObject = this.gameObject;
            GameObject bunnyFurObject = bunnyObject.GetComponentInChildren<SkinnedMeshRenderer>().gameObject;
            // bunnyFurObject.AddComponent<Light>();
            
            Material bunnyFurMaterial = bunnyFurObject.GetComponent<SkinnedMeshRenderer>().material;
            bunnyFurMaterial.EnableKeyword("_EMISSION");
            bunnyFurMaterial.SetColor("_EmissionColor",Color.green * 0.25f);
        }
    }
}