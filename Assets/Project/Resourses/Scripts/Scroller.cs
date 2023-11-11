using Assets.Project.Resourses.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasRaycaster))]
public class Scroller : MonoBehaviour
{
    [SerializeField] private float speedScroll = 0;
    [SerializeField] private Scrollble activeScrollble;
    [SerializeField] private CanvasRaycaster canvasRaycaster;

    private void OnLevelWasLoaded(int level)
    {
        Initialize();
    }

    private void Initialize()
    {
        InputService.OnClick0 += SetNewActiveObject;
        InputService.OnScroll += Scroll;
        canvasRaycaster = GetComponent<CanvasRaycaster>();
    }

    public void SetNewActiveObject()
    {
        List<RaycastResult> raycastResults = canvasRaycaster.GetAllRaycast();
        for (int i = 0; i < raycastResults.Count; i++)
        {
            if(raycastResults[i].gameObject.TryGetComponent(out activeScrollble))
            {
                break;
            }
        }
    }

    public void Scroll(Vector2 scrollVector)
    {
        if(activeScrollble != null)
            activeScrollble.Move(new Vector3(scrollVector.x, scrollVector.y, 0) * speedScroll);
    }
}
