using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class AfficherEcranSurClique : MonoBehaviour
{
    public GameObject ecranVR;
    private void Start()
    {

        // Récupère le composant XR Simple Interactable
        UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable>();

        // Ajoute un écouteur pour l'événement "Select Entered" (quand on clique)
        interactable.selectEntered.AddListener(OnObjectClicked);
    }
    private void OnObjectClicked(SelectEnterEventArgs args)
    {
        // Active ou désactive l'écran
        if (ecranVR != null)
        {
            bool estActif = ecranVR.activeSelf;
            ecranVR.SetActive(!estActif); // Inverse l'état (actif/désactivé)
        }
    }
    
}
