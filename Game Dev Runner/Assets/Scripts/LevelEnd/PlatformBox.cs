using TMPro;
using UnityEngine;

namespace GameDevRunner.LevelEnd
{
    public class PlatformBox : MonoBehaviour
    {
        [SerializeField] private TextMeshPro textMesh;

        private MeshRenderer mRenderer;

        public MeshRenderer MRenderer
        {
            get
            {
                if (mRenderer == null)
                    mRenderer = GetComponent<MeshRenderer>();

                return mRenderer;
            }
        }

        public void SetPotision(int index)
        {
            transform.localPosition = index * MRenderer.bounds.size.y * Vector3.up;
            textMesh.text = (10 * (index + 1)).ToString() + "M";
        }

        public void SetHeight(float targetHeight)
        {
            float targetYScale = (transform.localScale.y / MRenderer.bounds.size.y) * targetHeight;


            Vector3 scale = transform.localScale;
            scale.y = targetYScale;
            transform.localScale = scale;
        }

        public void SetMaterial(Material material)
        {
            MRenderer.material = material;
        }
    }
}