using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class WeatherSceneLoader : MonoBehaviour
{
    public TextMeshProUGUI temperatureText;
    public ApplyTheme theme;
    void Start()
    {
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
            temperatureText.text=$"{temp} C°";
            if (temp > 10)
            {
                SceneManager.LoadScene("EteScene", LoadSceneMode.Additive);
                theme.ApplySummerLighting();
            }
            else
            {
                SceneManager.LoadScene("HiverScene", LoadSceneMode.Additive);
                theme.ApplyWinterLighting();
            }
            Debug.Log("Température : " + temp);
        }
        else
        {
            Debug.LogError(request.error);
            temperatureText.text= "erreur";
        }
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