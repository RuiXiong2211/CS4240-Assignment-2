using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System;

public class ButtonHandler : MonoBehaviour {
    GameObject interaction;
    ARTapToPlaceObject scriptARTap;    
    public GameObject placeTable;
    public GameObject placeChair;
    GameObject andyGO;

    public void ChangeObjectTypeToTable()
    {
        interaction = GameObject.Find("Interaction");
        scriptARTap = interaction.GetComponent<ARTapToPlaceObject>();
        scriptARTap.objectToPlace = placeTable;
    }

    public void ChangeObjectTypeToChair()
    {
        interaction = GameObject.Find("Interaction");
        scriptARTap = interaction.GetComponent<ARTapToPlaceObject>();
        scriptARTap.objectToPlace = placeChair;
    }

    public void ChangeObjectTypeToAndy()
    {
        // controllerGO = GameObject.Find("Controller");
        // scriptMyHelloAR = controllerGO.GetComponent<MyHelloAR>();
        // andyGO = GameObject.Find("AndyGreen");
        // scriptMyHelloAR.AndyPlanePrefab = andyGO;
    }
}