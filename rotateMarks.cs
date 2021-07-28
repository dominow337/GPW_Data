using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateMarks : MonoBehaviour
{

	public float mouseSensitivity = 10f;
	public float xMouse = 3f;
	public float yMouse = 3f;
	public float zMouse = 3f;
	public Transform User;
	float xRotation = 0f;

	int i = 1;
	void Start()
	{
	}
	void Update()
	{ 
		if (i == 1)
		{
			//Obrót wykresów i jego elementów względem każdej z osi X, Y oraz Z Automatycznie w czasie rzeczywistym
			float mouseX = xMouse * mouseSensitivity * Time.deltaTime;
			
			xRotation -= mouseX;
			
			transform.localRotation = Quaternion.Euler(0f, xRotation, 0f);
			
		}
		if(i==-1)
        {
			//Obrót wykresów i jego elementów względem każdej z osi X, Y oraz Z Manualnie za pomocą klawiszy q i e
			if (Input.GetKey("q"))
            {
				float mouseX = xMouse * mouseSensitivity * Time.deltaTime;
				
				xRotation -= mouseX;
				
				transform.localRotation = Quaternion.Euler(0f, -xRotation, 0f);
				
			}
			else if(Input.GetKey("e"))
            {
				float mouseX = xMouse * mouseSensitivity * Time.deltaTime;
				
				xRotation -= mouseX;
				
				transform.localRotation = Quaternion.Euler(0f, xRotation, 0f);
				
			}
		}
		//zmiana trybu obrotu wykresu między Manualnym a Automatycznym
		if (Input.GetKeyDown("p"))
		{
			i = -i;
		}
	}
}
