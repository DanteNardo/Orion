

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
	private List<Wheel> Wheels;
	private float CenterOfMassOffset = -0.5f;

	/***************************************/
	/*               METHODS               */
	/***************************************/

	private void Awake() {
		// Get components
		RB = GetComponent<Rigidbody>();
		Wheels = new List<Wheel>(GetComponentsInChildren<Wheel>());

		// Offset center of mass
		var centerOfMass = RB.centerOfMass;
		centerOfMass.y += CenterOfMassOffset;
		RB.centerOfMass = centerOfMass;
	}

	private void FixedUpdate() {
		foreach (var wheel in Wheels) {
			wheel.Steering = steeringPositive.AsFloat + steeringNegative.AsFloat;
			wheel.MotorTorque = motorTorque.AsFloat;
			wheel.BrakeTorque = brakeTorque.AsFloat;
		}
	}

	/***************************************/
	/*              COROUTINES             */
	/***************************************/
}
