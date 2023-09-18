using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Kino
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(Camera))]
    [AddComponentMenu("Kino Image Effects/Binary")]
    public class Binary : MonoBehaviour
    {
        #region Editable attributes

        // Dither type selector
        public enum DitherType {
            Bayer2x2, Bayer3x3, Bayer4x4, Bayer8x8, BlueNoise64x64
        };

        [SerializeField] Material _material;


        // public ScriptableRendererFeature _blitRenderer;

        [SerializeField] DitherType _ditherType;

        public DitherType ditherType {
            get { return _ditherType; }
            set { _ditherType = value; }
        }

        // Scale factor of dither pattan
        [SerializeField, Range(1, 8)] int _ditherScale = 1;

        public int ditherScale {
            get { return _ditherScale; }
            set { _ditherScale = value; }
        }

        // Color (dark)
        [SerializeField] Color _color0 = Color.black;

        public Color color0 {
            get { return _color0; }
            set { _color0 = value; }
        }

        // Color (mid)
        [SerializeField] Color _color1 = Color.white;

        public Color color1 {
            get { return _color1; }
            set { _color1 = value; }
        }

        // Color (light)
        // [SerializeField] Color _color2 = Color.white;

        // public Color color2 {
        //     get { return _color2; }
        //     set { _color2 = value; }
        // }

        // Opacity
        [SerializeField, Range(0, 1)] float _opacity = 1.0f;

        public float Opacity {
            get { return _opacity; }
            set { _opacity = value; }
        }

        #endregion

        #region Private resources

        [SerializeField, HideInInspector] Shader _shader;

        [SerializeField, HideInInspector] Texture2D _bayer2x2Texture;
        [SerializeField, HideInInspector] Texture2D _bayer3x3Texture;
        [SerializeField, HideInInspector] Texture2D _bayer4x4Texture;
        [SerializeField, HideInInspector] Texture2D _bayer8x8Texture;
        [SerializeField, HideInInspector] Texture2D _bnoise64x64Texture;

        Texture2D DitherTexture {
            get {
                switch (_ditherType) {
                    case DitherType.Bayer2x2: return _bayer2x2Texture;
                    case DitherType.Bayer3x3: return _bayer3x3Texture;
                    case DitherType.Bayer4x4: return _bayer4x4Texture;
                    case DitherType.Bayer8x8: return _bayer8x8Texture;
                    default: return _bnoise64x64Texture;
                }
            }
        }


        #endregion

        #region MonoBehaviour implementation

        // void OnDestroy()
        // {
        //     if (_material != null)
        //         if (Application.isPlaying)
        //             Destroy(_material);
        //         else
        //             DestroyImmediate(_material);
        // }

        private void Update() {
            _material.SetTexture("_DitherTex", DitherTexture);
            _material.SetFloat("_Scale", _ditherScale);
            _material.SetColor("_Color0", _color0);
            _material.SetColor("_Color1", _color1);
            // _material.SetColor("_Color2", _color2);
            _material.SetFloat("_Opacity", _opacity);

        }

        // void OnRenderImage(RenderTexture source, RenderTexture destination)
        // {
        //     if (_material == null)
        //     {
        //         _material = new Material(_shader);
        //         _material.hideFlags = HideFlags.DontSave;
        //     }

        //     _material.SetTexture("_DitherTex", DitherTexture);
        //     _material.SetFloat("_Scale", _ditherScale);
        //     _material.SetColor("_Color0", _color0);
        //     _material.SetColor("_Color1", _color1);
        //     _material.SetFloat("_Opacity", _opacity);

        //     Graphics.Blit(source, destination, _material);
        // }

        #endregion
    }
}
