﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using BeamGameCode;

public class FrontendBikeFactory : MonoBehaviour
{
    // Ordered by backend BikeFactory.CtrlType

    public static readonly Dictionary<string,System.Type> bikeClassTypes =
        new Dictionary<string,System.Type>() {
        {BikeFactory.RemoteCtrl, typeof(FeRemoteBike)}, // remote bike.
        {BikeFactory.AiCtrl, typeof(FeAiBike)},  // AiCtrl - AI - controlled local bike
        {BikeFactory.LocalPlayerCtrl, typeof(FePlayerBike)} // LocalPlayerCtrl - a human on this machine
    };

    public GameObject bikePrefab;

    // Singleton management
    private static FrontendBikeFactory instance = null;
    public static FrontendBikeFactory GetInstance()
    {
        if (instance == null)
        {
            instance = (FrontendBikeFactory)GameObject.FindObjectOfType(typeof(FrontendBikeFactory));
            if (!instance)
                Debug.LogError("There needs to be one active FrontendBikeFactory script on a GameObject in your scene.");
        }

        return instance;
    }

    //
    // API
    //


    //
    // Utility
    //

	// Bike Factory stuff

    static public GameObject CreateBike(IBike ib, FeGround feGround, bool isLocal)
    {
        string feCtrlType = isLocal ? ib.ctrlType :  BikeFactory.RemoteCtrl;
        GameObject newBike = GameObject.Instantiate(FrontendBikeFactory.GetInstance().bikePrefab, utils.Vec3(ib.basePosition), Quaternion.identity) as GameObject;
		newBike.AddComponent(bikeClassTypes[feCtrlType]);
        newBike.transform.parent = feGround.transform;
        FrontendBike bk = (FrontendBike)newBike.transform.GetComponent("FrontendBike");

        IBeamFrontend fe = BeamMain.GetInstance().frontend;
		bk.Setup(ib, feGround, fe.beamAppl, fe.appCore);
        return newBike;
    }



}
