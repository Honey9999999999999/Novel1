using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowStart : MonoBehaviour
{
    public void Activate()
    {
        FindObjectOfType<Flowchart>().gameObject.SetActive(true);
    }
}
