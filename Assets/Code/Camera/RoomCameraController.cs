using UnityEngine;

public class RoomCameraController : MonoBehaviour
{
    private GameObject[] currentlyHiddenObjects;

    public void ChangeRoom(Transform cameraPoint)
    {
        if (cameraPoint == null)
            return;

        // Volver a mostrar los objetos de la cámara anterior
        ShowPreviousObjects();

        // Mover la cámara
        transform.position = cameraPoint.position;
        transform.rotation = cameraPoint.rotation;

        // Buscar qué objetos debe ocultar esta cámara
        CameraPoint cameraData = cameraPoint.GetComponent<CameraPoint>();

        if (cameraData != null)
        {
            currentlyHiddenObjects = cameraData.ObjectsToHide;

            HideCurrentObjects();
        }
    }

    private void HideCurrentObjects()
    {
        if (currentlyHiddenObjects == null)
            return;

        foreach (GameObject obj in currentlyHiddenObjects)
        {
            if (obj != null)
                obj.SetActive(false);
        }
    }

    private void ShowPreviousObjects()
    {
        if (currentlyHiddenObjects == null)
            return;

        foreach (GameObject obj in currentlyHiddenObjects)
        {
            if (obj != null)
                obj.SetActive(true);
        }

        currentlyHiddenObjects = null;
    }
}