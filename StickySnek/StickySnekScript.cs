using System;
using UnityEngine;

namespace StickySnek
{
    public class StickySnekScript : MonoBehaviour
    {
        public string debugText;
        public string _debugMetrics;
        private Rect _debugLogPosition;
        private float _fps = 0f;

        private void Awake()
        {
            debugText = "";
            _debugLogPosition = new Rect(0f, 0f, 1920f, 1080f);
        }

        private void OnGUI()
        {
            GUI.Label(_debugLogPosition, _debugMetrics + '\n' + debugText);
        }

        private void FixedUpdate()
        {
            _fps = 1f / Time.fixedDeltaTime;
            updateDebugMetrics();
        }

        private void updateDebugMetrics()
        {
            _debugMetrics = $"FPS: {_fps}";
        }
    }
}