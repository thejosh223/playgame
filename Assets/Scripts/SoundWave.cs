using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundWave : MonoBehaviour {

	public Vector3 velocity;
	public float speed = 5;
	public float startTime;

	void Update() {
		transform.LookAt(transform.position + velocity);
		transform.position += velocity.normalized * speed * Time.deltaTime;
		if (Time.time - startTime > 5)
			SoundwavePool.Instance.Add(this);
	}
}
