using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour
{
	Transform targetTransform;
	Transform currentTransform;

	private void Awake() {
		currentTransform = GetComponent<Transform>();
	}
	public void SetTarget(Transform targetTransform) {
		this.targetTransform = targetTransform;
		SetNewPos(targetTransform.position);
		enabled = true;
	}
	private void Update() {
		if (targetTransform != null) {
			SetNewPos(targetTransform.position);
		}
	}
	private void SetNewPos(Vector3 newPos) {
		newPos.z = 0;
		transform.position = newPos;
	}
	private void OnDisable() {
		enabled = false;
		targetTransform = null;
	}
}
