﻿

/*******************************************/
/*                  INCLUDES               */
/*******************************************/
using UnityEngine;

/*******************************************/
/*                   CLASS                 */
/*******************************************/
public class FrontWheel : WheelController {

	/***************************************/
	/*               MEMBERS               */
	/***************************************/


	/***************************************/
	/*              PROPERTIES             */
	/***************************************/
	public float Steering { get; set; }

	/***************************************/
	/*               METHODS               */
	/***************************************/
	private new void FixedUpdate() {
		base.FixedUpdate();
		Wheel.steerAngle = Steering;
	}

	/***************************************/
	/*              COROUTINES             */
	/***************************************/
}