using System;
using System.Collections.Generic;
using UnityEngineUIExpansion;
namespace UnityEngine.UI
{
    [AddComponentMenu("UI/BUI Text", 10)]
    public class BUIText : Text
    {
        //[SerializeField] private bool m_OutLine = true;
        //[SerializeField] private Color m_OutLineColor = Color.black;
        //[SerializeField] private float m_OutLineOffsetX = 1f;
        //[SerializeField] private float m_OutLineOffsetY = -1f;

        //UIVertex[] m_TempVerts = new UIVertex[4];
        //protected override void OnPopulateMesh(VertexHelper toFill)
        //{
        //    if (font == null)
        //        return;

        //    // We don't care if we the font Texture changes while we are doing our Update.
        //    // The end result of cachedTextGenerator will be valid for this instance.
        //    // Otherwise we can get issues like Case 619238.
        //    m_DisableFontTextureRebuiltCallback = true;

        //    Vector2 extents = rectTransform.rect.size;

        //    var settings = GetGenerationSettings(extents);
        //    cachedTextGenerator.PopulateWithErrors(text, settings, gameObject);

        //    // Apply the offset to the vertices
        //    IList<UIVertex> verts = cachedTextGenerator.verts;
        //    float unitsPerPixel = 1 / pixelsPerUnit;
        //    //Last 4 verts are always a new line... (\n)
        //    int vertCount = verts.Count - 4;

        //    // We have no verts to process just return (case 1037923)
        //    if (vertCount <= 0)
        //    {
        //        toFill.Clear();
        //        return;
        //    }

        //    Vector2 roundingOffset = new Vector2(verts[0].position.x, verts[0].position.y) * unitsPerPixel;
        //    roundingOffset = PixelAdjustPoint(roundingOffset) - roundingOffset;
        //    toFill.Clear();
        //    if (roundingOffset != Vector2.zero)
        //    {
        //        for (int i = 0; i < vertCount; ++i)
        //        {
        //            int tempVertsIndex = i & 3;
        //            m_TempVerts[tempVertsIndex] = verts[i];
        //            m_TempVerts[tempVertsIndex].position *= unitsPerPixel;
        //            m_TempVerts[tempVertsIndex].position.x += roundingOffset.x;
        //            m_TempVerts[tempVertsIndex].position.y += roundingOffset.y;
        //            if (tempVertsIndex == 3)
        //                toFill.AddUIVertexQuad(m_TempVerts);
        //        }
        //    }
        //    else
        //    {
        //        for (int i = 0; i < vertCount; ++i)
        //        {
        //            int tempVertsIndex = i & 3;
        //            m_TempVerts[tempVertsIndex] = verts[i];
        //            m_TempVerts[tempVertsIndex].position *= unitsPerPixel;
        //            if (m_OutLine && tempVertsIndex == 3)
        //            {
        //                ApplyShadowZeroAlloc(ref m_TempVerts, m_OutLineColor, m_OutLineOffsetX, m_OutLineOffsetY, toFill);
        //                ApplyShadowZeroAlloc(ref m_TempVerts, m_OutLineColor, m_OutLineOffsetX, -m_OutLineOffsetY, toFill);
        //                ApplyShadowZeroAlloc(ref m_TempVerts, m_OutLineColor, -m_OutLineOffsetX, m_OutLineOffsetY, toFill);
        //                ApplyShadowZeroAlloc(ref m_TempVerts, m_OutLineColor, -m_OutLineOffsetX, -m_OutLineOffsetY, toFill);
        //                toFill.AddUIVertexQuad(m_TempVerts);
        //            }
        //        }
        //    }

        //    m_DisableFontTextureRebuiltCallback = false;
        //}
        //private void ApplyShadowZeroAlloc(ref UIVertex[] rVertex, Color rEffectColor, float rEffectDistanceX, float rEffectDistanceY, VertexHelper rHelper)
        //{
        //    for (int i = 0; i < rVertex.Length; i++)
        //    {
        //        Vector3 rPosition = rVertex[i].position;
        //        rPosition.x += rEffectDistanceX;
        //        rPosition.y += rEffectDistanceY;
        //        rVertex[i].position = rPosition;
        //        rVertex[i].color = rEffectColor;
        //    }
        //    rHelper.AddUIVertexQuad(rVertex);
        //    for (int i = 0; i < rVertex.Length; i++)
        //    {
        //        Vector3 rPosition = rVertex[i].position;
        //        rPosition.x -= rEffectDistanceX;
        //        rPosition.y -= rEffectDistanceY;
        //        rVertex[i].color = color;
        //        rVertex[i].position = rPosition;
        //    }
        //}

        Action _onChangeCallback;
        public override string text
        {
            get
            {
                return UIBaseExp.A(m_Text);
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    if (String.IsNullOrEmpty(m_Text))
                        return;
                    m_Text = "";
                    SetVerticesDirty();
                }
                else if (m_Text != value)
                {
                    m_Text = value;
                    SetVerticesDirty();
                    SetLayoutDirty();
                    if (_onChangeCallback != null)
                    {
                        _onChangeCallback();
                    }
                }
            }
        }

        public void RegisterChangeCallback(Action action)
        {
            _onChangeCallback = action;
        }

        public void UnRegisterChangeCallback()
        {
            _onChangeCallback = null;
        }
    }

    public static class Text_Extension
    {
        public static string GetText(this Text _this)
        {
            return UIBaseExp.A(_this.text);
        }
    }


}
