using UnityEngine;
using Random = UnityEngine.Random;

namespace StickySnek
{
    public class GoldbarScript : MonoBehaviour
    {
        private GameObject goldbarObject;
        private Light goldBarLight;
        private float goldbarLightRange = 1f;
        private Material goldBarMaterial;
        private static readonly int EmissionColor = Shader.PropertyToID("_EmissionColor");
        private float intensity = 0f;
        private float intensityDecayRate = 0.05f;
        private Color goldColor = new(1.000f, 0.843f, 0.000f);
        private GameObject player = GameObject.FindGameObjectWithTag("Player");
        private float distanceToPlayer = 0f;
        private float minDistanceToPlayer = 5f;
        private float intensityCoefficient = 0f;
        private float rangeCoefficient = 0f;
        private float intensityEffective = 0f;
        private float rangeEffective = 0f;

        void Start()
        {
            goldbarObject = this.gameObject;
            goldBarLight = goldbarObject.AddComponent<Light>();
            goldBarMaterial = goldbarObject.GetComponent<MeshRenderer>().material;
            goldBarMaterial.EnableKeyword("_EMISSION");
            goldBarLight.color = goldColor;
        }

        private void Update()
        {
            distanceToPlayer = Vector3.Distance(player.transform.position, goldbarObject.transform.position);
            intensityCoefficient = Mathf.Min(Mathf.Max((distanceToPlayer - minDistanceToPlayer), 0.1f) / 10f,1f);
            rangeCoefficient = Mathf.Max((distanceToPlayer - minDistanceToPlayer) / 30f, 0.1f);
            if (Random.value >= 0.95) intensity += 1f;
            IntensityDecay();
            UpdateLighting();
        }

        private void IntensityDecay()
        {
            if (intensity < 0.1) intensity = 0;
            if (intensity == 0) return;
            intensity -= intensity * intensityDecayRate;
            intensityEffective = intensity * intensityCoefficient;
            rangeEffective = goldbarLightRange * rangeCoefficient;
        }

        private void UpdateLighting()
        {
            goldBarLight.intensity = intensityEffective;
            goldBarLight.range = rangeEffective;
            goldBarMaterial.SetColor(EmissionColor, goldColor * intensityEffective * 0.5f);
        }
    }
}