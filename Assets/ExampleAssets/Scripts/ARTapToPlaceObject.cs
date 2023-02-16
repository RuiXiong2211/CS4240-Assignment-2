using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System;
using UnityEngine.EventSystems; 

public class ARTapToPlaceObject : MonoBehaviour
{
    public GameObject placementIndicator;
    
    private Pose PlacementPose;
    private ARRaycastManager aRRaycastManager;
    private bool placementPoseIsValid = false;
    Camera arCam;
    private bool isAdd; // Keeps track if the next tap will Add or Delete element.
    public GameObject objectToPlace;
    private List<GameObject> createdObjects;
    private GameObject objDetected;
    
    // Start is called before the first frame update
    void Start()
    {
        arCam = GameObject.Find("AR Camera").GetComponent<Camera>();
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlacementPose();
        UpdatePlacementIndicator();
        if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)) // checks if it's not pressing a UI element (button).
        {
            if (placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                PlaceObject();
            }
            if (!isAdd && !placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                DeleteObject();
            }
        }
        
    }

    private void PlaceObject() 
    {
        GameObject created = Instantiate(objectToPlace, PlacementPose.position, objectToPlace.transform.rotation);
        createdObjects.Add(created);
    }

    private void DeleteObject() 
    {
        Destroy(objDetected);
    }

    private void UpdatePlacementPose() 
    {
        //var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var screenCenter = arCam.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);
        RaycastHit hit;
        bool hitObject = false;
        isAdd = true;
        //Ray ray = arCam.ScreenPointToRay(Input.GetTouch(0).position);
        Ray ray = arCam.ScreenPointToRay(screenCenter);
        if (Physics.Raycast(ray, out hit)) {
            if (hit.collider.gameObject.tag == "Spawnable") {
                objDetected = hit.transform.gameObject;
                hitObject = true;
                isAdd = false;
            }
        }
        placementPoseIsValid = hits.Count > 0 && !hitObject;
        if (placementPoseIsValid) 
        {
            PlacementPose = hits[0].pose;
        }
    }

    private void UpdatePlacementIndicator() 
    {
        if (placementPoseIsValid) 
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(PlacementPose.position, PlacementPose.rotation);
        }
        else 
        {
            placementIndicator.SetActive(false);
        }
    }
}
