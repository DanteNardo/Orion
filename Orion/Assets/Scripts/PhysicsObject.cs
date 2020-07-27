

/*******************************************/
/*                  INCLUDES               */
/*******************************************/
using UnityEngine;

/*******************************************/
/*                   CLASS                 */
/*******************************************/
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class PhysicsObject : MonoBehaviour {

    /***************************************/
    /*               MEMBERS               */
    /***************************************/
    // Short name to discourage use
    public float m;
    private float im;

    // Short name to discourage use
    public Vector3 a;
    public Vector3 acceleration_min;
    public Vector3 acceleration_max;

    // Short name to discourage use
    public Vector3 v;
    public Vector3 velocity_min;
    public Vector3 velocity_max;

	/***************************************/
	/*              PROPERTIES             */
	/***************************************/
    public float Mass {
        get { return m; }
        set {
            m = value;
            im = 1 / m;
            Rigidbody.mass = m;
        }
	}
    public float InverseMass {
        get { return im; }
    }
    public Vector3 Acceleration {
        get { return a; }
        set {
            a = new Vector3(
                Mathf.Clamp(value.x, acceleration_min.x, acceleration_max.x),
                Mathf.Clamp(value.y, acceleration_min.y, acceleration_max.y),
                Mathf.Clamp(value.z, acceleration_min.z, acceleration_max.z)
            );
        }
    }
    public Vector3 Velocity { 
        get { return v; }
        set {
            v = new Vector3(
                Mathf.Clamp(value.x, velocity_min.x, velocity_max.x),
                Mathf.Clamp(value.y, velocity_min.y, velocity_max.y),
                Mathf.Clamp(value.z, velocity_min.z, velocity_max.z)
            );
            Rigidbody.velocity = v;
        }
    }
	public Rigidbody Rigidbody { get; private set; }

	/***************************************/
	/*               METHODS               */
	/***************************************/
	private void Awake() {
        CheckForBadInstantiation();
    }

	private void Start() {
        // Get components
        Rigidbody = GetComponent<Rigidbody>();
        
        // Instantiate physics variables
        Mass = m;
        Acceleration = a;
        Velocity = v;
    }

	private void FixedUpdate() {
        PhysicsUpdate();
    }

    private void CheckForBadInstantiation() {
        if (Mass <= 0) {
            Debug.LogError("Mass is less than or equal to 0");
            Debug.Log("Mass: " + Mass);
        }
        if (velocity_min.x >= velocity_max.x ||
            velocity_min.y >= velocity_max.y ||
            velocity_min.z >= velocity_max.z) {
            Debug.LogError("velocity_min member is greater than or equal to velocity_max");
            Debug.Log("Velocity_Min: {" + velocity_min.x + ", " + velocity_min.y + ", " + velocity_min.z + "}");
            Debug.Log("Velocity_Max: {" + velocity_max.x + ", " + velocity_max.y + ", " + velocity_max.z + "}");
        }
    }

    private void PhysicsUpdate() {
        Velocity += Acceleration;
    }

    public void AddForce(Force force) {
        /***********************************/
        /*           EQUATIONS             */
        /************************************
         * Force = Mass * Acceleration, OR 
         * Force / Mass = Acceleration
         */

        // Add this force and use inverse mass for speed
        Acceleration += force.Get() * InverseMass;
	}

	/***************************************/
	/*              COROUTINES             */
	/***************************************/
}
