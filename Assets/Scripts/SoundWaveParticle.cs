using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundWaveParticle : MonoBehaviour {

	private float timeToKill;

	void Update() {
		if (Time.time >= timeToKill) 
			SoundWaveParticlePool.Instance.Add(this);
	}

	public void SetParticleInfo(Vector3 pos, Quaternion rot, float t) {
		transform.position = pos;
		transform.rotation = rot;
		timeToKill = Time.time + t;
	}
}
