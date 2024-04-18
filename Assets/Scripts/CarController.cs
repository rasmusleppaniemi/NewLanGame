using UnityEngine;
using System;
using System.Collections.Generic;

public class CarController : MonoBehaviour
{
    public enum ControlMode
    {
        Keyboard,
        Buttons
    };

    public enum Axel
    {
        Front,
        Rear
    }

    [Serializable]
    public struct Wheel
    {
        public GameObject wheelModel;
        public WheelCollider wheelCollider;
        public Axel axel;
    }

    public ControlMode control;

    public float maxAcceleration = 30.0f;
    public float brakeAcceleration = 50.0f;

    public float turnSensitivity = 1.0f;
    public float maxSteerAngle = 30.0f;

    public Vector3 _centerOfMass;

    public List<Wheel> wheels;

    float moveInput;
    float steerInput;

    private Rigidbody carRb;

    AudioManager audioManager;
    bool isIdleSoundPlaying;
    public void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Start()
    {
        carRb = GetComponent<Rigidbody>();
        carRb.centerOfMass = _centerOfMass;
    }

    void Update()
    {
        GetInputs();
        AnimateWheels();
    }

    void LateUpdate()
    {
        Move();
        Steer();
        Brake();
    }

    public void MoveInput(float input)
    {
        moveInput = input;
    }

    public void SteerInput(float input)
    {
        steerInput = input;
    }

    public float movementThreshold = 0.1f; // Adjust this value as needed

    void GetInputs()
    {
        if (control == ControlMode.Keyboard)
        {
            moveInput = Input.GetAxis("Vertical");
            steerInput = Input.GetAxis("Horizontal");
        }

        // Check if the car is moving
        bool isMoving = IsCarMoving();

        if (!isMoving || carRb.velocity.magnitude < movementThreshold)
        {
            // Check if the idle sound is not already playing
            if (!isIdleSoundPlaying)
            {
                // Play the idle sound once and set it to loop
                audioManager.PlaySFX(audioManager.EngineIdle);
                audioManager.SFXSource.loop = true;
                isIdleSoundPlaying = true; // Set flag to indicate idle sound is playing
            }
        }
        else
        {
            // Stop the idle sound if it's playing
            if (isIdleSoundPlaying)
            {
                audioManager.StopSFX();
                audioManager.PlaySFX(audioManager.Driving);
                isIdleSoundPlaying = false; // Reset flag since idle sound is no longer playing
            }
        }
    }

    bool IsCarMoving()
    {
        foreach (var wheel in wheels)
        {
            if (wheel.wheelCollider.rpm != 0)
            {
                return true;
            }
        }
        return false;
    }




    void Move()
    {
        foreach (var wheel in wheels)
        {
            wheel.wheelCollider.motorTorque = -moveInput * 600 * maxAcceleration * Time.deltaTime;
        }
    }

    void Steer()
    {
        foreach (var wheel in wheels)
        {
            if (wheel.axel == Axel.Front)
            {
                var _steerAngle = steerInput * turnSensitivity * maxSteerAngle;
                wheel.wheelCollider.steerAngle = Mathf.Lerp(wheel.wheelCollider.steerAngle, _steerAngle, 0.6f);
            }
        }
    }

    void Brake()
    {
        if (Input.GetKey(KeyCode.Space) || moveInput == 0)
        {
            foreach (var wheel in wheels)
            {
                wheel.wheelCollider.brakeTorque = 300 * brakeAcceleration * Time.deltaTime;
            }
        }
        else
        {
            foreach (var wheel in wheels)
            {
                wheel.wheelCollider.brakeTorque = 0;
            }
        }
    }

    void AnimateWheels()
    {
        foreach (var wheel in wheels)
        {
            Quaternion rot;
            Vector3 pos;
            wheel.wheelCollider.GetWorldPose(out pos, out rot);
            wheel.wheelModel.transform.position = pos;
            wheel.wheelModel.transform.rotation = rot;
        }
    }
}