using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXEffector : MonoBehaviour
{
	[SerializeField] Transform topMenuCoinsTargetPos;
    [SerializeField] ParticleSystem[] retrieveCoinsUiEffects;
	public static VFXEffector Instance;
	void Awake() {
		Instance = this;
	}
	public void CoinEffect(Vector3 pos) {
		var uiEffect = retrieveCoinsUiEffects.FirstOrDefault(x => !x.gameObject.activeInHierarchy);
		if (uiEffect != null) {
			uiEffect.gameObject.SetActive(true);
			var newPos = pos; 
			newPos.z = 0;
			uiEffect.transform.position = newPos;
			StartCoroutine(StopCoins(uiEffect));
		}
	}
	private IEnumerator StopCoins(ParticleSystem ps) {
		yield return new WaitForSeconds(0.35f);
		ps.GetComponent<Position>().SetTarget(topMenuCoinsTargetPos);
		yield return new WaitForSeconds(3);
		ps.Stop();
		ps.gameObject.SetActive(false);
	}
}
