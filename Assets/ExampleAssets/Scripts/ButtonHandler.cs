using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System;

public class ButtonHandler : MonoBehaviour {

    public GameObject placeTable;
    public GameObject placeChair;
    public GameObject placeBed;

    private GameObject interaction;
    private ARTapToPlaceObject scriptARTap;

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

    public void ChangeObjectTypeToBed()
    {
        interaction = GameObject.Find("Interaction");
        scriptARTap = interaction.GetComponent<ARTapToPlaceObject>();
        scriptARTap.objectToPlace = placeBed;
    }
}