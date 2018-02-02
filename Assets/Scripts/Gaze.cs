using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This Script was inspired by a tutorial by Timmy Kokke
[RequireComponent(typeof(MeshRenderer))]
public class Gaze : MonoBehaviour {

	public Material GazeOnMaterial;
	public Material GazeOffMaterial;
	public Camera camera;
	public Canvas canvas;
	public float canvasDistance = .5f;
	public float fillIncrement = 0.5f;
	public float fillWidth = 1.5f;

	private MeshRenderer meshRenderer;
	private GazeTarget previousTarget;

	// Use this for initialization
	void Start () {
		this.meshRenderer = GetComponent<MeshRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 headPos = camera.transform.position;
		Vector3 gazeDir = camera.transform.forward;

		RaycastHit hitInfo;

		if (Physics.Raycast (headPos, gazeDir, out hitInfo)) {
			meshRenderer.enabled = true;
			this.transform.position = hitInfo.point;
			this.transform.rotation = Quaternion.FromToRotation (Vector3.up, hitInfo.normal);

			GazeTarget gazeTarget = hitInfo.collider.gameObject.GetComponent<GazeTarget> ();

			if (gazeTarget == null || gazeTarget != previousTarget) {
				RectTransform fillImageTransform =  canvas.transform.Find("FillImage").transform as RectTransform;
				fillImageTransform.sizeDelta = new Vector2 (0f, fillImageTransform.sizeDelta.y);

			}


			if (gazeTarget != null) {
				meshRenderer.material = this.GazeOnMaterial;

				// TODO: Get the message from the gazeTarget
				string message = gazeTarget.getInfoText();

				// Render the canvas;
				Transform child =  canvas.transform.Find("Text");
				Text t = child.GetComponent<Text>();
				t.text = message;


				// Render the canvas between the object and the camera
				canvas.transform.position = hitInfo.point + Vector3.down * canvasDistance;
				canvas.transform.rotation = Quaternion.FromToRotation (Vector3.forward, hitInfo.normal);
				canvas.enabled = true;


				// Fill the bar
				RectTransform fillImageTransform =  canvas.transform.Find("FillImage").transform as RectTransform;

				if (fillImageTransform.rect.width >= fillWidth) {
					gazeTarget.Act ();
				} else {

					float newWidth = Mathf.Min(fillWidth, fillImageTransform.rect.width + fillIncrement * Time.deltaTime);
					fillImageTransform.sizeDelta = new Vector2 (newWidth, fillImageTransform.sizeDelta.y);
				}

				previousTarget = gazeTarget;
			} else {
				meshRenderer.material = this.GazeOffMaterial;
				canvas.enabled = false;
			}

		} else {
			meshRenderer.enabled = false;
		}
	}
}
