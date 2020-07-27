

/*******************************************/
/*                  INCLUDES               */
/*******************************************/
using UnityEngine;

/*******************************************/
/*                   CLASS                 */
/*******************************************/
public class Force {

    /***************************************/
    /*               MEMBERS               */
    /***************************************/
    private Vector3 force;
    public bool force_enabled = true;

    /***************************************/
    /*              PROPERTIES             */
    /***************************************/


    /***************************************/
    /*               METHODS               */
    /***************************************/
    public Force(float force) {
        this.force = new Vector3(force, force, force);
	}

    public Force(Vector3 force) {
        this.force = force;
	}

    public Vector3 Get() {
        if (force_enabled) {
            return force;
        }
        else return Vector3.zero;
	}

    public void Update(Vector3 force) {
        this.force = force;
	}
}
