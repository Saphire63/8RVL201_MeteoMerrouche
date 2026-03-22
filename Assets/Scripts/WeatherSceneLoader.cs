using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Teleportation;
using System.Collections;
using TMPro;
using ThemesApplier;

public class WeatherSceneLoader : MonoBehaviour
{
    public TextMeshProUGUI temperatureText;
    public ApplyTheme theme;

    void Start()
    {
        if (theme == null)
            theme = GetComponent<ApplyTheme>();
        Debug.Log("Lancée script weather");
        StartCoroutine(GetWeather());
    }

    IEnumerator GetWeather()
    {
        string url = "https://api.open-meteo.com/v1/forecast?latitude=48.42&longitude=-71.06&current_weather=true";
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            WeatherData data = JsonUtility.FromJson<WeatherData>(request.downloadHandler.text);
            float temp = data.current_weather.temperature;
            temperatureText.text = $"{temp} C°";

            if (temp > 5)
            {
                Debug.Log("summer");
                SceneManager.LoadScene("EteScene", LoadSceneMode.Additive);
                yield return null; // attend que la scène soit chargée
                AssignTeleportComponents();
                theme.ApplySummerLighting();
            }
            else
            {
                SceneManager.LoadScene("HiverScene", LoadSceneMode.Additive);
                yield return null; // attend que la scène soit chargée
                AssignTeleportComponents();

                if (theme == null)
                    Debug.Log("probleme dans WeatherSceneLoader.cs");
                else
                    theme.ApplyWinterLighting();
            }

            Debug.Log("Température : " + temp);
        }
        else
        {
            Debug.LogError(request.error);
            temperatureText.text = "erreur";
        }
    }

    void AssignTeleportComponents()
    {
        XRInteractionManager manager = FindObjectOfType<XRInteractionManager>();
        TeleportationProvider provider = FindObjectOfType<TeleportationProvider>();

        if (manager == null)
            Debug.LogError("XRInteractionManager introuvable dans CoreScene !");
        if (provider == null)
            Debug.LogError("TeleportationProvider introuvable dans CoreScene !");

        TeleportationArea[] areas = FindObjectsOfType<TeleportationArea>();
        foreach (var area in areas)
        {
            area.interactionManager = manager;
            area.teleportationProvider = provider;
        }

        Debug.Log($"{areas.Length} TeleportationArea(s) configurée(s) !");
    }
}

[System.Serializable]
public class WeatherData
{
    public CurrentWeather current_weather;
}

[System.Serializable]
public class CurrentWeather
{
    public float temperature;
}