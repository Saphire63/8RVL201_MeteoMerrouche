using UnityEngine;
namespace ThemesApplier{
public class ApplyTheme : MonoBehaviour
    {
        [Header("Skybox")]
        public Material winterSkybox;
        public Material summerSkybox;

        [Header("Directional Light (Sun)")]
        public Light directionalLight;

        // ❄️ HIVER
        public void ApplyWinterLighting()
        {
            Debug.Log("Apply Winter Lighting");
            RenderSettings.fog = true;
            RenderSettings.fogColor = new Color(0.75f, 0.8f, 0.85f);
            RenderSettings.fogDensity = 0.015f;

            if (winterSkybox != null)
                RenderSettings.skybox = winterSkybox;

            RenderSettings.ambientLight = new Color(0.65f, 0.7f, 0.75f);
            RenderSettings.ambientIntensity = 0.7f;



            if (directionalLight != null)
            {
                directionalLight.intensity = 0.6f;
                directionalLight.color = new Color(0.8f, 0.85f, 1f);
            }
        }

        // ☀️ ÉTÉ
        public void ApplySummerLighting()
        {
            Debug.Log("Apply Summer Lighting");

            RenderSettings.fog = true;
            RenderSettings.fogColor = new Color(0.9f, 0.9f, 0.85f);
            RenderSettings.fogDensity = 0.003f;

            if (summerSkybox != null)
                RenderSettings.skybox = summerSkybox;

            RenderSettings.ambientLight = new Color(1f, 0.98f, 0.9f);
            RenderSettings.ambientIntensity = 1.1f;


            if (directionalLight != null)
            {
                directionalLight.intensity = 1.1f;
                directionalLight.color = new Color(1f, 0.98f, 0.95f);
            }
        }
    }
}