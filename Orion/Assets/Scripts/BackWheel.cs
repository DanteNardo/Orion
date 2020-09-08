

/*******************************************/
/*                  INCLUDES               */
/*******************************************/
using UnityEngine;

/*******************************************/
/*                   CLASS                 */
/*******************************************/
public class BackWheel : WheelController {

	/***************************************/
	/*               MEMBERS               */
	/***************************************/


	/***************************************/
	/*              PROPERTIES             */
	/***************************************/
	public float MotorTorque { get; set; }
	public float BrakeTorque { get; set; }

	/***************************************/
	/*               METHODS               */
	/***************************************/
	private new void FixedUpdate() {
		base.FixedUpdate();
		Wheel.motorTorque = MotorTorque;
		Wheel.brakeTorque = BrakeTorque;
	}

	/***************************************/
	/*              COROUTINES             */
	/***************************************/
}
