using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Controllables;
using VRTK.Controllables.ArtificialBased;

public class SimpleCarController : MonoBehaviour {

    public Vector3 check;

    public float m_horizontalInput = 0;
    public float m_verticalInput = 0;
    public float m_StopInput = 0;
    public float m_steeringAngle;


    public VRTK_BaseControllable SpeedObj;
    public VRTK_BaseControllable Wheele;
    public VRTK_BaseControllable StopObj;
    public WheelCollider FrontLeftW, FrontRightW;
    public WheelCollider BackLeftW, BackRightW;
    public Transform FrontLeftT, FrontRightT;
    public Transform BackLeftT, BackRightT;
    public float maxSteerAngle = 30;
    public float MaxMotorForce = -200;
    public float motorForce = -200;
    public float MaxStopForce = -1000;
    Rigidbody rig;
    public float speed;

    public float MSpeed;
    public float MStop;



    protected virtual void OnEnable()
    {
        rig = GetComponent<Rigidbody>();
        SpeedObj = (SpeedObj == null ? GetComponent<VRTK_BaseControllable>() : SpeedObj);
        SpeedObj.ValueChanged += ValueChanged;
        Wheele = (Wheele == null ? GetComponent<VRTK_BaseControllable>() : Wheele);
        Wheele.ValueChanged += WValueChanged;
        StopObj = (StopObj == null ? GetComponent<VRTK_BaseControllable>() : StopObj);
        StopObj.ValueChanged += StopObj_ValueChanged;



    }

    private void StopObj_ValueChanged(object sender, ControllableEventArgs e)
    {
        m_StopInput = e.value;
    }

    private void WValueChanged(object sender, ControllableEventArgs e)
    {
        m_horizontalInput = e.value;
    }

    private void ValueChanged(object sender, ControllableEventArgs e)
    {
        m_verticalInput = e.value;
    }

    public void GetInput()
	{
        //m_horizontalInput = Input.GetAxis("Horizontal");
        //m_verticalInput = Input.GetAxis("Vertical");
        m_horizontalInput = Wheele.GetComponent<VRTK_ArtificialRotator>().GetValue();
        //print("h " + m_horizontalInput);
        m_verticalInput =( SpeedObj.GetComponent<VRTK_ArtificialRotator>().GetValue() - 45) / 45;
        //m_verticalInput = (SpeedObj.GetComponent<VRTK_ArtificialRotator>().GetStepValue;
        print("v " + m_verticalInput);
    }

	private void Steer()
	{
		m_steeringAngle = maxSteerAngle * m_horizontalInput;
        FrontLeftW.steerAngle = m_steeringAngle;
        FrontRightW.steerAngle = m_steeringAngle;
	}

	private void Accelerate()
	{
        FrontLeftW.motorTorque = m_verticalInput * motorForce;
        FrontRightW.motorTorque = m_verticalInput * motorForce;
        FrontLeftW.brakeTorque = m_StopInput * MaxStopForce;
        FrontRightW.brakeTorque = m_StopInput * MaxStopForce;
    }

	private void UpdateWheelPoses()
	{
		UpdateWheelPose(FrontLeftW, FrontLeftT);
		UpdateWheelPose(FrontRightW, FrontRightT);
		UpdateWheelPose(BackLeftW, BackLeftT);
		UpdateWheelPose(BackRightW, BackRightT);
	}

	private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
	{

        Vector3 _pos = new Vector3();
        Quaternion _quat = new Quaternion();

        _collider.GetWorldPose(out _pos, out _quat);

        if (_collider == BackRightW || _collider == BackLeftW)
        {
            _quat *= Quaternion.Euler(0, 180, 0);
        }
        _transform.position = _pos;
        _transform.rotation = _quat;

    }

	private void FixedUpdate()
	{
        speed = rig.velocity.magnitude;
        motorForce = MaxMotorForce + speed / 3 * 200;
        //GetInput();
        Steer();
		Accelerate();
		UpdateWheelPoses();


        MSpeed = FrontLeftW.motorTorque;
        MStop = FrontLeftW.brakeTorque;

    }

}
