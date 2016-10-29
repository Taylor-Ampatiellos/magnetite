using UnityEngine;
using System.Collections;

public class Magnetic : MonoBehaviour
{
	public LayerMask m_MagneticLayers;
	public Vector3 m_Position;
	float m_Radius = 10;
	float m_Force = 0;
	enum Polarity {pos, neg, none};
	Polarity polar = Polarity.none;

	void Update ()
	{
		if (Input.GetMouseButtonDown(0)) {
			if (polar == Polarity.pos) {
				m_Force = 0;
				polar = Polarity.none
			} else {
				m_Force = 50;
				polar = Polarity.pos;
			}
		}

		if (Input.GetMouseButtonDown(1)) {
			if (polar == Polarity.neg) {
				m_Force = 0;
				polar = Polarity.none
			} else {
				m_Force = -50;
				polar = Polarity.neg;
			}
		}
	}

	void FixedUpdate () 
	{
		Collider[] colliders;
		Rigidbody rigidbody;

		colliders = Physics.OverlapSphere (transform.position + m_Position, m_Radius, m_MagneticLayers);
		foreach (Collider collider in colliders) {
			rigidbody = (Rigidbody)collider.gameObject.GetComponent (typeof(Rigidbody));
			if (rigidbody == null) {
				continue;
			}
			rigidbody.AddExplosionForce (m_Force * -1, transform.position + m_Position, m_Radius);
		}

	}

	void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position + m_Position, m_Radius);
	}
}