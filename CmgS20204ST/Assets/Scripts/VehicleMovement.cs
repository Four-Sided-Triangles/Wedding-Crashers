using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum DriveType
{
	RearWheelDrive,
	FrontWheelDrive,
	AllWheelDrive
}
public class VehicleMovement : MonoBehaviour
{

	public float maxAngle = 30f;
	public float maxTorque = 300f;
	public float brakeTorque = 30000f;
	//public GameObject wheelShape;

	public float criticalSpeed = 5f;
	public int stepsBelow = 5;
	public int stepsAbove = 1;

	public DriveType driveType;
	public WheelCollider[] m_Wheels = new WheelCollider[4];

	// Find all the WheelColliders down in the hierarchy.
	void Start()
	{

	}

	// This is a really simple approach to updating wheels.
	// We simulate a rear wheel drive car and assume that the car is perfectly symmetric at local zero.
	// This helps us to figure our which wheels are front ones and which are rear.
	void Update()
	{
		m_Wheels[0].ConfigureVehicleSubsteps(criticalSpeed, stepsBelow, stepsAbove);

		float angle = maxAngle * Input.GetAxis("Horizontal");
		float torque = maxTorque * Input.GetAxis("Vertical");

		float handBrake = Input.GetKey(KeyCode.X) ? brakeTorque : 0;

		foreach (WheelCollider wheel in m_Wheels)
		{
			// A simple car where front wheels steer while rear ones drive.
			if (wheel.transform.localPosition.x > 0)
				wheel.steerAngle = angle;

			if (wheel.transform.localPosition.x < 0)
			{
				wheel.brakeTorque = handBrake;
			}

			if (wheel.transform.localPosition.x < 0)
			{
				wheel.motorTorque = torque;
			}

			if (wheel.transform.localPosition.x >= 0)
			{
				wheel.motorTorque = torque;
			}
			/*
			// Update visual wheels if any.
			if (wheelShape)
			{
				Quaternion q;
				Vector3 p;
				wheel.GetWorldPose(out p, out q);

				// Assume that the only child of the wheelcollider is the wheel shape.
				Transform shapeTransform = wheel.transform.GetChild(0);

				if (wheel.name == "a0l" || wheel.name == "a1l" || wheel.name == "a2l")
				{
					shapeTransform.rotation = q * Quaternion.Euler(0, 180, 0);
					shapeTransform.position = p;
				}
				else
				{
					shapeTransform.position = p;
					shapeTransform.rotation = q;
				}
			}
			*/
		}
	}
}
