using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Teleportation;
using System.Collections;
using ThemesApplier;

public class SceneSwitcher : MonoBehaviour
{
    public ApplyTheme theme;

    void Start()
    {
        if (theme == null)
            theme = FindObjectOfType<ApplyTheme>();
    }

    public void SwitchScene()
    {
        if (SceneManager.GetSceneByName("HiverScene").isLoaded)
            StartCoroutine(SwitchTo("HiverScene", "EteScene", isSummer: true));
        else
            StartCoroutine(SwitchTo("EteScene", "HiverScene", isSummer: false));
    }

    IEnumerator SwitchTo(string sceneToUnload, string sceneToLoad, bool isSummer)
    {
        SceneManager.UnloadSceneAsync(sceneToUnload);
        SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);

        yield return null;

        AssignTeleportComponents();

        if (isSummer)
            theme.ApplySummerLighting();
        else
            theme.ApplyWinterLighting();
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