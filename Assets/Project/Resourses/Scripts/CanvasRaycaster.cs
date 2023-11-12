using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace Assets.Project.Resourses.Scripts
{
    [RequireComponent(typeof(GraphicRaycaster))]
    public class CanvasRaycaster : MonoBehaviour
    {
        [SerializeField] GraphicRaycaster m_Raycaster;
        PointerEventData m_PointerEventData;
        EventSystem m_EventSystem;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            m_Raycaster = GetComponent<GraphicRaycaster>();
            m_EventSystem = EventSystem.current;
        }

        public List<RaycastResult> GetAllRaycast()
        {
            m_PointerEventData = new PointerEventData(m_EventSystem);
            m_PointerEventData.position = Input.mousePosition;

            List<RaycastResult> results = new();

            m_Raycaster.Raycast(m_PointerEventData, results);

            return results;
        }

        public RaycastResult GetNearRaycast()
        {
            List<RaycastResult> results = GetAllRaycast();
            return results[0];
        }
    }
}
