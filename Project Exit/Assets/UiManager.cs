using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public float RayLength = 3f;
    public GameObject KeyItemPng;
    public GameObject InteractableItemPng;
    public GameObject TileInteractPng;
    private Camera MainCamera;

    private void Start()
    {
        MainCamera = Camera.main;
    }
    private void Update()
    {
        Vector3 screenCenter = new Vector3(Screen.width / 2.0f, Screen.height / 2.0f, 0);
        Ray ray = MainCamera.ScreenPointToRay(screenCenter);
        
        KeyItemPng.SetActive(false);
        InteractableItemPng.SetActive(false);
        TileInteractPng.SetActive(false);
        if (Physics.Raycast(ray, out RaycastHit hit, RayLength))
        {
            if (hit.collider.gameObject.GetComponent<KeyItem>())
            {
                KeyItemPng.SetActive(true);
            }
            else if (hit.collider.gameObject.GetComponent<InteractableObject>())
            {
                InteractableItemPng.SetActive(true);
            }
            else if (hit.collider.gameObject.GetComponent<TileSkript2_0>())
            {
                TileInteractPng.SetActive(true);
            }

        }
    }
}
