using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CursorCapturer : MonoBehaviour {	
	private MouseLook[] mouseLooks;
	private bool _captureCursor = true;

	void Awake() {
		_singleton = this;
	}
	
	void Start() {
		mouseLooks = GetComponentsInChildren<MouseLook>();
	}
	
	void Update() {
		/*
		 * Capturing of the Camera
		 */
		if (_captureCursor) {
			Screen.lockCursor = true;
			for (int i = 0; i < mouseLooks.Length; i++)
				mouseLooks[i].enabled = Screen.lockCursor;
		} else {
			Screen.lockCursor = false;
			for (int i = 0; i < mouseLooks.Length; i++)
				mouseLooks[i].enabled = false;
		}
	}
	
	public bool CaptureCursor {
		get { return _captureCursor;}
		set { _captureCursor = value; }
	}
	
	private static CursorCapturer _singleton;
	
	public static CursorCapturer Instance {
		get { return _singleton; }
	}
}
