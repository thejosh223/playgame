using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : Component {
	private List<T> objects;
	// Can set a parent folder to store objects in the pool in
	public Transform ParentFolder;
	// Static pointer to an instance of this
	public static ObjectPool<T> Instance;
	// Activating and deactivating objects can be slow - almost as slow as instantiating them
	// Set to false to leave objects active
	public bool AutoActive = true;
	// Number to allocate at once when more are needed
	public int NumToAllocate = 5;
	// The object to instantiate
	public T prefab;
	
	void Awake() {
		objects = new List<T>();
		Instance = this;
	}
	
	// Create new objects and but them in the pool
	public void Allocate(T obj, int number) {
		// TODO: Can we run the object's Awake/Start methods, and then clone THAT one that's already set up, further reducing creation time?
		for (int i = 0; i < number; i++) {
			T newObj = (T)Instantiate(obj);
			newObj.name = obj.name; // Get rid of the "(clone)" designation
			Add(newObj);
		}
	}
	
	// Get an object from the pool
	public T Get() {
		if (objects.Count == 0) {
			Allocate(prefab, NumToAllocate);
		}
		T returnObj = objects[0];
		objects.RemoveAt(0);

		if (AutoActive)
			returnObj.gameObject.SetActive(true);
		return returnObj;
	}
	
	// Add an object into the pool
	public void Add(T obj) {
		if (AutoActive)
			obj.gameObject.SetActive(false);
		obj.transform.parent = ParentFolder; // Keep things tidy
		objects.Add(obj);
	}
}