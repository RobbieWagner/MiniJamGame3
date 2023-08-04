//Adapted from Brackeys Portal Tutorial https://www.youtube.com/watch?v=cuQao3hEKfs&t=171s
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetup : MonoBehaviour {

	[SerializeField] private List<Camera> portalCameras;

	[SerializeField] private List<Material> cameraMats;

	//Sets up portal camera textures when starting
	private void Awake() 
    {
        for(int i = 0; i < portalCameras.Count; i++)
        {
            Camera portalCamera = portalCameras[i];
            Material cameraMat = cameraMats[i];

            if (portalCamera.targetTexture != null)
            {
                portalCamera.targetTexture.Release();
            }
            portalCamera.targetTexture = new RenderTexture(Camera.main.pixelWidth, Camera.main.pixelHeight, 24);
            cameraMat.mainTexture = portalCamera.targetTexture;
        }
	}
	
}