using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Archer
{

    public class CameraController : MonoBehaviour
    {

        // El objeto al que va a seguir la cámara
        [SerializeField]
        private Transform target;

        // Ángulo de la cámara
        [SerializeField]
        private float angle;

        // Distancia a la que se coloca la cámara con respecto a la arquera
        [SerializeField]
        private float distance;

        // Desplazamiento con respecto al pivote de la arquera 
        // (para que la cámara esté más orienta hacia la cabeza que a los pies)
        [SerializeField]
        private Vector3 offset;
        
        // Velocidad a la que se mueve la cámara con Vector3.MoveTowards()
        //[SerializeField]
        //private float travelSpeed;

        // Tiempo que tarda la cámara en moverse a la nueva ubicación con Vector3.Lerp()
        [SerializeField]
        private float travelTime;

        private void Update()
        {

            Vector3 camPos = Quaternion.Euler(angle, 0,0) * (new Vector3(0,0,-1) * distance);
            camPos = Quaternion.Euler(0, target.transform.eulerAngles.y, 0) * camPos;
            camPos += target.transform.position;
            transform.LookAt(target.transform.position+offset);
            //camPos += offset;
            transform.position = Vector3.Lerp(transform.position, camPos,travelTime) ;
            
        }

    }

}
