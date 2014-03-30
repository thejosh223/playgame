using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundWave : MonoBehaviour {

	public Vector3 velocity;
	public float speed = 5;

	// Sound Wave Particles
	public float spawnInterval;
	public float lastSpawnTime = -1;

	// Killing Information
	public float startTime = -1;

	void Update() {
		// Move this Physics-ally
		RaycastHit hit;
		if (Physics.Raycast(transform.position, velocity, out hit, speed * Time.deltaTime)) {
			float remainingDistance = speed * Time.deltaTime - hit.distance;
			velocity = Vector3.Reflect(velocity, hit.normal).normalized;
			transform.position = hit.point + velocity * remainingDistance;
		} else {
			transform.position += velocity.normalized * speed * Time.deltaTime;
		}

		transform.LookAt(transform.position + velocity);

		// Spawn particles
		if (Time.time - lastSpawnTime >= spawnInterval) {
			SoundWaveParticle s = SoundWaveParticlePool.Instance.Get();
			s.SetParticleInfo(transform.position, Quaternion.LookRotation(transform.forward), 2f);

			lastSpawnTime = Time.time;
		}

		// Kill this object
		if (Time.time - startTime > 5) {
			SoundWavePool.Instance.Add(this);
		}
	}

	public void StartWave(Vector3 direction) {
		velocity = direction.normalized;
		speed = direction.magnitude;

		spawnInterval = 1f / speed;

		startTime = Time.time;
		lastSpawnTime = Time.time;
	}
}
