

/*******************************************/
/*                  INCLUDES               */
/*******************************************/
using System.Collections.Generic;
using UnityEngine;

/*******************************************/
/*                   CLASS                 */
/*******************************************/
[RequireComponent(typeof(PhysicsObject))]
public class KinematicController : MonoBehaviour {

	/***************************************/
	/*               MEMBERS               */
	/***************************************/

	// Constants 
	const float GRAVITY = -9.81f;

	// Components
	private PhysicsObject physics_object;

	/***************************************/
	/*              PROPERTIES             */
	/***************************************/
	private List<Force> Forces { get; set; } = new List<Force>();
	public Force Gravity = new Force(new Vector3(0, GRAVITY, 0));
	public Force Friction = new Force(new Vector3(0, 0, 0));
	public Force Drag = new Force(new Vector3(0, 0, 0));

	/***************************************/
	/*               METHODS               */
	/***************************************/
	private void Start() {
		physics_object = GetComponent<PhysicsObject>();
		Forces.Add(Gravity);
		Forces.Add(Friction);
	}

	private void FixedUpdate() {
		foreach (var force in Forces) {
			physics_object.AddForce(force);
		}
	}

	/***************************************/
	/*              COROUTINES             */
	/***************************************/
}
