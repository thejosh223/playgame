using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

	private Camera eyeCam;

	void Start() {
		eyeCam = GetComponentInChildren<Camera>();
	}

	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			SoundWave t = SoundWavePool.Instance.Get();
			t.transform.position = transform.position + Vector3.up;

			t.StartWave(eyeCam.transform.forward * 5f);
		}
	}
}
