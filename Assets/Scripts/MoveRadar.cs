using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveRadar : MonoBehaviour
{

    [SerializeField]private GameObject radar;


public void MoveRadarToPos()
    {
        radar.transform.position = transform.position;  
    }

}
