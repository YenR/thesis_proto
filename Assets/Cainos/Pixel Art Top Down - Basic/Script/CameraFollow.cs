using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    //let camera follow target
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;
        public float lerpSpeed = 1.0f;

        private Vector3 offset;

        private Vector3 targetPos;

        private void Start()
        {
            if (target == null) return;

            offset = Vector3.zero; //= transform.position - target.position;
            transform.position = target.position;
            transform.position.Set(transform.position.x, transform.position.y, -10);

            if (LevelLoader.startpos != null && LevelLoader.startpos != Vector2.zero)
            {
                this.gameObject.transform.Translate(LevelLoader.startpos);
            }
        }

        private void Update()
        {
            if (target == null) return;

            targetPos = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);

            transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        }

    }
}
