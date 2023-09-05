using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GyroScopeControls : MonoBehaviour
{

    Gyroscope m_Gyro;

    void Start()
    {
        //Set up and enable the gyroscope (check your device has one)
        m_Gyro = Input.gyro;
        m_Gyro.enabled = true;
    }

    
}
