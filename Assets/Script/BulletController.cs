using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {
	
	[HideInInspector]
	public Vector3 direct = Vector3.up;
	
	public float speed = 4;
	
	private readonly static float margine = 0.02f;
	
	void Start () {
		GameObject dust = GameObject.Find("dustbox") as GameObject;
		if( dust == null)
			dust = new GameObject("dustbox");
		transform.parent = dust.transform;
		
		AudioClip shootAudio = Resources.Load("Audio/shot1") as AudioClip;
		AudioSource.PlayClipAtPoint(shootAudio, Vector3.zero);
	}
	
	void Update () {
		
		if( Time.timeScale == 0 )
			return;
		
		transform.position += direct * speed;
		
		Vector3 bulletScreenPos = Camera.mainCamera.WorldToViewportPoint( transform.position);
		if( bulletScreenPos.x  < 0 - margine || bulletScreenPos.x  > 1 + margine || 
			bulletScreenPos.y  < 0 - margine || bulletScreenPos.y  > 1 + margine )
			Destroy(gameObject);
	}
	
	public void Stop()
	{
		enabled = false;
	}
	
	void OnTriggerEnter( Collider collision )
	{
		if( collision.gameObject.tag != "Player")
			Destroy (gameObject);
	}

}