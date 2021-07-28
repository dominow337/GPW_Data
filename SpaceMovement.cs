using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class SpaceMovement : MonoBehaviour
    {
        public Interactable focus;

        Camera cam;
        //kontrola poruszania kamerą
        public CharacterController controller;
        public float speed = 12f;
        Texture2D myTexture;

        public Text nazwa;
        public Text wolumen;
        public Text stopazwrotu;
        public GameObject chart1;

        public Text nazwa1;
        public Text wolumen1;
        public Text stopazwrotu1;
        public GameObject chart2;

        public Text nazwa2;
        public Text wolumen2;
        public Text stopazwrotu2;
        public GameObject chart3;

        int i = 0;
        int j = 0;
        int k = 0;
        
        void Start()
        {
            Cursor.visible = true;
            cam = Camera.main;

            nazwa.text = "Nazwa: ";
            wolumen.text = "Wolumen: ";
            stopazwrotu.text = "Stopa Zwrotu: ";

            nazwa1.text = "Nazwa: ";
            wolumen1.text = "Wolumen: ";
            stopazwrotu1.text = "Stopa Zwrotu: ";

            nazwa2.text = "Nazwa: ";
            wolumen2.text = "Wolumen: ";
            stopazwrotu2.text = "Stopa Zwrotu: ";
        }
   
        void Update()
        {

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            Vector3 move = transform.right * x + transform.forward * z; //schemat poruszania się za pomocą klawiszy WSAD

            controller.Move(move * speed * Time.deltaTime);//funkcja wprawiająca w ruch kamerę

            
            //funkja imitująca grawitację i w efekcie sprowadzenie kamery do punktu zero na osi Y
           
            
            if(Input.GetKey("escape"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }

            if (Input.GetMouseButtonDown(1))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 10))
                {
                    RemoveFocus();
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                var ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100))
                {
                    Debug.Log("We hit " + hit.collider.name + " " + hit.point);
                    Interactable interactable = hit.collider.GetComponent<Interactable>();
                    if (interactable != null)
                    {
                        SetFocus(interactable);
                        if (i == 0)
                        {
                            nazwa.text = "Nazwa: " + interactable.Nazwa;
                            stopazwrotu.text = "Stopa Zwrotu: " + interactable.StopaZwrotu;
                            wolumen.text = "Wolumen: " + interactable.Wolumen;
                            myTexture = Resources.Load("matplotlib charts/" + nazwa.text) as Texture2D;

                            chart1.GetComponent<RawImage>().texture = myTexture;
                            i++;
                        }
                        else if (j == 0)
                        {
                            nazwa1.text = "Nazwa: " + interactable.Nazwa;
                            stopazwrotu1.text = "Stopa Zwrotu: " + interactable.StopaZwrotu;
                            wolumen1.text = "Wolumen: " + interactable.Wolumen;
                            myTexture = Resources.Load("matplotlib charts/" + nazwa1.text) as Texture2D;

                            chart2.GetComponent<RawImage>().texture = myTexture;
                            j++;
                        }
                        else if(k == 0)
                        {
                            nazwa2.text = "Nazwa: " + interactable.Nazwa;
                            stopazwrotu2.text = "Stopa Zwrotu: " + interactable.StopaZwrotu;
                            wolumen2.text = "Wolumen: " + interactable.Wolumen;
                            myTexture = Resources.Load("matplotlib charts/" + nazwa2.text) as Texture2D;

                            chart3.GetComponent<RawImage>().texture = myTexture;
                            k++;
                        }
                        //nazwa.text = interactable.name;
                        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    }
                }

            }

            if(Input.GetKey("1"))
            {
                nazwa.text = "Nazwa: ";
                wolumen.text = "Wolumen: ";
                stopazwrotu.text = "Stopa Zwrotu: ";
                
                i = 0;
            }
            if(Input.GetKey("2"))
            {
                nazwa1.text = "Nazwa: ";
                wolumen1.text = "Wolumen: ";
                stopazwrotu1.text = "Stopa Zwrotu: ";
                j = 0;
            }
            if(Input.GetKey("3"))
            {
                nazwa2.text = "Nazwa: ";
                wolumen2.text = "Wolumen: ";
                stopazwrotu2.text = "Stopa Zwrotu: ";
                k = 0;
            }
     
        }
        void SetFocus(Interactable newFocus)
        {
            if (newFocus != focus)
            {
                if (focus != null)
                    focus.OnDefocused();

                focus = newFocus;
            }
            newFocus.OnFocused(transform);
        }
        internal void RemoveFocus()
        {
            if (focus != null)
                focus.OnDefocused();
            focus = null;
        }
    }
}