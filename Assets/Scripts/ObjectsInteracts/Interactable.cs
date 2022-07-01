using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private bool isInteractable;
    private Renderer _renderer;
    private IInteract interactable;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        interactable = GetComponent<IInteract>();
    }

    private void OnMouseOver()
    {
        List<Material> mats = _renderer.materials.ToList();
        foreach(var mat in mats)
        {
            mat.SetColor("_OutlineColor", Color.red);
        }

        if (Input.GetMouseButtonDown(0))
        {
            interactable.ActivateObject();
        }
    }

    private void OnMouseExit()
    {
        List<Material> mats = _renderer.materials.ToList();
        foreach (var mat in mats)
        {
            mat.SetColor("_OutlineColor", Color.black);
        }
    }
}
