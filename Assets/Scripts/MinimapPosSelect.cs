using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinimapPosSelect : MonoBehaviour
{
    [SerializeField] private Transform[] spawnInLocation;
    [SerializeField] private NavMeshAgent player;

    [SerializeField] private GameObject[] cameraLocation;
    public static int currentCameraIndex = 0;

    [SerializeField] GameObject dialogue;
    
    public void TeleportToPlace(int place)
    {
        if (place == 4)
        {
            
        }
        else
        {
            if (currentCameraIndex != place)
            {
                player.Warp(spawnInLocation[place].position);
                cameraLocation[currentCameraIndex].SetActive(false);
                cameraLocation[place].SetActive(true);
                currentCameraIndex = place;
            }
        }
    }
}