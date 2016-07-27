using UnityEngine;

namespace Assets.Scripts.Skills
{

    public class SkillController : MonoBehaviour
    {
        [Tooltip("The life time of skill (after object will be destroyed)")]
        public float lifeTime = 5;
        [Tooltip("Determines speed for skill. If you dont need this leave 1 (by default).")]
        public float speed = 1;
        public float instantiateOffset = 0;
        [Tooltip("Determines direction for skill. If you dont need this leave [0,0,0] (by default).")]
        public Vector3 direction = Vector3.zero;
        [Tooltip("Determines start rotation for skill. If you dont need this leave [0,0,0] (by default).")]
        public Vector3 startRotation = Vector3.zero;
        [Tooltip("Determines start y-offset. If you dont need this leave 0 (by default)")]
        public float startY = 0;
        [Tooltip("Determines is skill a buff.")]
        public bool followByTarget = false;
        public bool rotateByTarget = false;
        GameObject target;

        void Awake()
        {
            // find target, which will be geometrical center for skills.
            target = GameObject.FindGameObjectWithTag("Character");
            // move skill efect into center of target.
            transform.position = new Vector3(target.transform.position.x, startY, target.transform.position.z) + target.transform.forward * instantiateOffset;
            // rotate gameobject for skill in target's direction
            transform.rotation = target.transform.rotation;
            // if previous step isn't necessary - rotate gameobject on startRotation vector.
            // but if previous step is neccessary - startRotation vector must be [0,0,0] (by default)
            transform.Rotate(startRotation);
        }

        void FixedUpdate()
        {
            // transforming position of skill if its need in direction vector.
            if(direction != Vector3.zero)
            {
                transform.Translate(direction * speed * Time.deltaTime);
            }
            // make skill follow by target if its need
            if (followByTarget)
            {
                transform.position = new Vector3(target.transform.position.x, startY, target.transform.position.z);
            }
            // make skill rotate by target if its need
            if (rotateByTarget)
            {
                transform.rotation = target.transform.rotation;
            }
        }

        void Update()
        {
            Destroy(gameObject, lifeTime);
        }
    }
}
