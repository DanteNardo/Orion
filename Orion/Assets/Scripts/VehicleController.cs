

/*******************************************/
/*                  INCLUDES               */
/*******************************************/
using System.Collections.Generic;
using UnityEngine;

/*******************************************/
/*                   CLASS                 */
/*******************************************/
[RequireComponent(typeof(Rigidbody))]
public class VehicleController: MonoBehaviour {

	/***************************************/
	/*               MEMBERS               */
	/***************************************/
	public UnityCurve.UnityCurve steeringPositive;
	public UnityCurve.UnityCurve steeringNegative;
	public UnityCurve.UnityCurve motorTorque;
	public UnityCurve.UnityCurve brakeTorque;

	/***************************************/
	/*              PROPERTIES             */
	/***************************************/
	private Rigidbody RB { get; set; }
	private List<FrontWheel> FrontWheels;
	private List<BackWheel> BackWheels;
	//private float CenterOfMassOffset = -0.5f;

	/***************************************/
	/*               METHODS               */
	/***************************************/

	private void Awake() {
		// Get components
		RB = GetComponent<Rigidbody>();
		FrontWheels = new List<FrontWheel>(GetComponentsInChildren<FrontWheel>());
		BackWheels = new List<BackWheel>(GetComponentsInChildren<BackWheel>());

		// Offset center of mass
		//var centerOfMass = RB.centerOfMass;
		//centerOfMass.y += CenterOfMassOffset;
		//RB.centerOfMass = centerOfMass;
	}

	private void FixedUpdate() {
		foreach (var frontWheel in FrontWheels) {
			frontWheel.Steering = steeringPositive.AsFloat + steeringNegative.AsFloat;
		}

		foreach (var backWheel in BackWheels) {
			backWheel.MotorTorque = motorTorque.AsFloat;
			backWheel.BrakeTorque = brakeTorque.AsFloat;
		}
	}

	/***************************************/
	/*              COROUTINES             */
	/***************************************/
}
