using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowStart : MonoBehaviour
{
    [SerializeField] private Flowchart flowchart;
    public void Activate()
    {
        flowchart.gameObject.SetActive(true);
    }
}
