using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{

	public float mouseSensitivity = 100f;
	public Transform User;
	float xRotation = 0f;

	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked; //blokada kursora myszy na środku ekranu aplikacji
	}


	void Update()
	{
		//obrót kamery za pomocą myszy
		float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
		float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
		xRotation -= mouseY;
		xRotation = Mathf.Clamp(xRotation, -90f, 90f); //blokada obrotu względem osi X 
		transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
		User.Rotate(Vector3.up * mouseX);

	}
}
