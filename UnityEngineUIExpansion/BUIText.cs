using System;
using System.Collections.Generic;
using UnityEngineUIExpansion;
using System.Text.RegularExpressions;
using System.Text;
using System.Collections;

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
        Font defaultFont;
        string originalText;
        public static string Blitz_Language = "blitz_language";
        Coroutine delayFrameIEnumerator;
        //下一次改变是否使用callback 解决UILocalization刷新大小写问题
        public bool useCallBackNext = true;
        public string OriginalText
        {
            get
            {
                if (originalText != null)
                    return UIBaseExp.A(originalText);
                else
                    return UIBaseExp.A(m_Text);
            }
            set
            {

            }
        }
        public override string text
        {
            get
            {
                //if (string.IsNullOrEmpty(originalText))
                    return UIBaseExp.A(m_Text);
                //else
                    //return UIBaseExp.A(originalText);
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
#if UNITY_ANDROID && !UNITY_EDITOR
                    //this.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
#else
                    string deviceSystem = SystemInfo.operatingSystem;
                    if (deviceSystem.Contains("iOS"))
                    {
                        try
                        {
                            if (defaultFont == null)
                                defaultFont = this.font;
                            int num = int.Parse(deviceSystem.Replace("iOS", "").Split('.')[0].Trim());
                            if (num >= 13)
                            {
                                string input = @"[\u0E00-\u0E7F]"; // 包含:@"[\u0E00-\u0E7F]" 全部:@"^[\u0E00-\u0E7F]+$"
                                if (Regex.IsMatch(value, input))
                                {
                                    this.font = Resources.Load("Font/NotoSerifThai-SemiCondensedMedium") as Font;
                                }
                                else if (this.font != defaultFont)
                                    this.font = defaultFont;
                                //this.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
                            }
                        }
                        catch (Exception)
                        {
                            Debug.LogError("解析系统版本格式错误: " + SystemInfo.operatingSystem);
                            this.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
                        }
                    }
#endif
                    originalText = value;
                    //Debug.LogError(this.gameObject.name + "   " + value);
                    if (TextUtils.IsRTLInput(value))
                    {
                        CheckTextPivot();
                    }
                    else
                    {
                        m_Text = value;
                        SetVerticesDirty();
                        SetLayoutDirty();
                        if (_onChangeCallback != null)
                        {
                            if (useCallBackNext)
                                _onChangeCallback();
                            else
                                useCallBackNext = true;
                        }
                    }
                }
            }
        }

        //大量开启协程会导致大量GC 先检查是否为拉伸性Text 仅考虑X轴拉伸 Y轴不考虑
        private void CheckTextPivot()
        {
            if (rectTransform.anchorMin.x.Equals(0) && rectTransform.anchorMax.x.Equals(1) && gameObject.activeInHierarchy)
            {
                //防止一帧调用多次text方法 取最后一次的值
                if (delayFrameIEnumerator != null)
                    StopCoroutine(delayFrameIEnumerator);
                delayFrameIEnumerator = StartCoroutine(delayFrameFixArabia());
            }
            else
                FixArabia();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            if (!String.IsNullOrEmpty(originalText))
            {
                if (TextUtils.IsRTLInput(m_Text))
                {
                    CheckTextPivot();
                }
            }
        }

        //这里等一帧主要是为了拉伸类型的Text只有在创建/渲染之后才能取到长度宽度 TextGenerator
        IEnumerator delayFrameFixArabia()
        {
            yield return null;
            FixArabia();
        }

        private void FixArabia()
        {
            m_Text = originalText;
            m_Text = FixArabicUITextLines(false, false, m_Text);
            m_Text = FixColorSymble(m_Text);
            SetVerticesDirty();
            SetLayoutDirty();
            if (_onChangeCallback != null)
            {
                if (useCallBackNext)
                    _onChangeCallback();
                else
                    useCallBackNext = true;
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

        public string FixArabiaString(string target)
        {
            target = FixArabicUITextLines(false, false, target);
            target = FixColorSymble(target);
            return target;
        }

        //fix = true && leftdown = false的情况为 从左向右换行 并且每行自动转方向
        //fix = false && leftdown = true 从右向左换行 并且每行不自动转方向
        private string FixArabicUITextLines(bool useTashkeel, bool hinduNumbers, string text, bool Fix = true, bool leftDown = false)
        {
            fillColor = false;
            //if (PlayerPrefs.GetString(Blitz_Language) != "ar")
            {
                if (!TextUtils.IsRTLInput(text))
                    return text;
            }
            if (string.IsNullOrEmpty(text))
                return text;
            if (this == null)
            {
                if (Fix)
                    return ReturnP(ArabicFixer.Fix(text, useTashkeel, hinduNumbers));
                else
                    return text;
            }
            if (GetComponent<ContentSizeFitter>() != null && GetComponent<ContentSizeFitter>().horizontalFit == ContentSizeFitter.FitMode.PreferredSize)
            {
                if (Fix)
                    return ReturnP(ArabicFixer.Fix(text, useTashkeel, hinduNumbers));
                else
                    return text;
            }

            TextGenerator textGenerator = GetTextGenerator(text);

            string reversedText = "";
            string tempLine;
            //Debug.LogError(textGenerator.lineCount + " start: " + text);
            string targetCol = FindColor(text);
            if (textGenerator.lineCount <= 1)
            {
                if (Fix)
                    return ReturnP(ArabicFixer.Fix(text, useTashkeel, hinduNumbers));
                else
                    return text;
            }
            for (int i = 0; i < textGenerator.lineCount; i++)
            {
                int startIndex = textGenerator.lines[i].startCharIdx;
                int endIndex = i < textGenerator.lines.Count - 1 ? textGenerator.lines[i + 1].startCharIdx : text.Length;
                tempLine = text.Substring(startIndex, endIndex - startIndex);
                string result = "";
                if (Fix)
                    result = ReturnP(ArabicFixer.Fix(tempLine, useTashkeel, hinduNumbers).Trim('\n'));
                else
                    result = tempLine.Trim('\n');
                //Debug.Log(i + "  pre: " + result);
                if (!string.IsNullOrEmpty(targetCol))
                    result = FixAribiaOneLineColor(result, targetCol);
                //Debug.Log(i + "  res: " + result);
                if (leftDown)
                {
                    reversedText = result + reversedText;
                    if (i != textGenerator.lineCount - 1)
                        reversedText = Environment.NewLine + reversedText;
                }
                else
                {
                    reversedText += result;
                    if (i != textGenerator.lineCount - 1)
                        reversedText += Environment.NewLine;
                }
            }
            //Debug.LogError("end: " + reversedText);

            return reversedText;
        }


        private TextGenerator GetTextGenerator(string text)
        {
            TextGenerator textGenerator = new TextGenerator();
            Vector2 size = rectTransform.rect.size;
            var element = GetComponent<LayoutElement>();
            if (element != null && element.preferredWidth > 0)
            {
                size = new Vector2(element.preferredWidth, element.preferredHeight);
            }
            //if (size.x <= 0)
            //{
            //    Debug.LogError(size.x + "  " + textUI.name);
            //    if (transform.parent != null && transform.parent.GetComponent<RectTransform>() != null)
            //        size.x = transform.parent.GetComponent<RectTransform>().sizeDelta.x + rectTransform.rect.size.x;
            //    Debug.LogError(textUI.transform.parent.GetComponent<RectTransform>().sizeDelta.x + "  " + textUI.transform.parent.name);
            //    if (size.x <= 0)
            //    {
            //        size.x = 300;
            //        Debug.LogError(name + "   :没有长度 " + rectTransform.sizeDelta.x);
            //    }
            //}
            //if (size.y < 5000)
            //    size.y = 5000;
            if (size.x <= 0)
            {
                Debug.LogError(gameObject.name + "   :没有长度 " + rectTransform.rect.size);
                //防止一帧调用多次text方法 取最后一次的值
                if (gameObject.activeInHierarchy)
                {
                    if (delayFrameIEnumerator != null)
                        StopCoroutine(delayFrameIEnumerator);
                    delayFrameIEnumerator = StartCoroutine(delayFrameFixArabia());
                }
            }
            TextGenerationSettings generationSettings = GetGenerationSettings(size);
            textGenerator.Populate(text, generationSettings);
            //Debug.LogError(size + "  " + textGenerator.lineCount + "   " + text);

            return textGenerator;
        }

        //由于颜色符不能嵌套 所以如果不对称出现 只能多一个
        //中东版从右往左读时 修复单行文本颜色符
        //如果一行中只有<color=#FFFFFF>或者<color=#FFFFFF>比</color>多
        //那么把<color=#FFFFFF>移到行首 在原位加上</color>

        //如果一行中先</color> 后<color=#FFFFFF>(中东版反过来)
        //在行首填上<color=#FFFFFF> 在行位填上</color>

        //如果一行中只有</color>或者</color>比<color=#FFFFFF>多
        //那么把</color>移到行尾 在原位加上<color=#FFFFFF>

        //防止出现颜色符夸三行 只变了前后 没变中间的情况 如果上一行颜色符区域多的话 此值为true
        private bool fillColor = false;
        private string FixAribiaOneLineColor(string preText, string preCol)
        {
            string[] logChar = preText.Split(new char[] { '<', '>' });
            List<string> targetCol = new List<string>();
            int startCount = 0;
            int endCount = 0;
            for (int i = 0; i < logChar.Length; ++i)
            {
                if (logChar[i].Contains("color="))
                {
                    targetCol.Add(logChar[i]);
                    startCount++;
                }
                else if (logChar[i].Contains("/color"))
                {
                    targetCol.Add(logChar[i]);
                    endCount++;
                }
            }

            //没有颜色符
            if (startCount == 0 && endCount == 0)
            {
                if (fillColor)
                {
                    string result = preCol + preText + "</color>";
                    return result;
                }
                else
                {
                    return preText;
                }
            }

            if (startCount > endCount)
                fillColor = true;
            else
                fillColor = false;

            if (startCount > endCount)
            {
                bool canChange = true;
                for (int i = 0; i < logChar.Length; ++i)
                {
                    if (logChar[i].Contains("color=") && canChange)
                    {
                        logChar[i] = "</color>";
                        canChange = false;
                    }
                    else if (logChar[i].Equals("a href=point") || logChar[i].Equals("/a") || logChar[i].Contains("color"))
                    {
                        logChar[i] = "<" + logChar[i] + ">";
                    }
                }
                StringBuilder s = new StringBuilder();
                s.Append(preCol);
                for (int i = 0; i < logChar.Length; ++i)
                    s.Append(logChar[i]);
                return s.ToString();
            }
            else if (startCount == endCount)
            {
                if (targetCol[0].Contains("color="))
                {
                    for (int i = 0; i < logChar.Length; ++i)
                    {
                        if (logChar[i].Equals("a href=point") || logChar[i].Equals("/a") || logChar[i].Contains("color"))
                        {
                            logChar[i] = "<" + logChar[i] + ">";
                        }
                    }
                    StringBuilder s = new StringBuilder();
                    s.Append(preCol);
                    for (int i = 0; i < logChar.Length; ++i)
                        s.Append(logChar[i]);
                    s.Append("</color>");
                    return s.ToString();
                }
            }
            else
            {
                bool canChange = true;
                for (int i = 0; i < logChar.Length; ++i)
                {
                    if (logChar[i].Contains("/color") && canChange)
                    {
                        logChar[i] = preCol;
                        canChange = false;
                    }
                    else if (logChar[i].Equals("a href=point") || logChar[i].Equals("/a") || logChar[i].Contains("color"))
                    {
                        logChar[i] = "<" + logChar[i] + ">";
                    }
                }
                StringBuilder s = new StringBuilder();
                for (int i = 0; i < logChar.Length; ++i)
                    s.Append(logChar[i]);
                s.Append("</color>");
                return s.ToString();
            }
            return preText;
        }
        //找目标color
        private string FindColor(string text)
        {
            string[] logChar = text.Split(new char[] { '<', '>' });
            string targetCol = "";
            for (int i = 0; i < logChar.Length; ++i)
            {
                if (logChar[i].Contains("color="))
                {
                    targetCol = logChar[i];
                    break;
                }
            }
            return "<" + targetCol + ">";
        }

        //多语言最后的文本 修正color符号
        private string FixColorSymble(string preText)
        {
            string[] logChar = preText.Split(new char[] { '<', '>' });
            Dictionary<int, string> targetCol = new Dictionary<int, string>();
            for (int i = 0; i < logChar.Length; ++i)
            {
                if (logChar[i].Contains("color="))
                {
                    targetCol.Add(targetCol.Count, logChar[i]);
                }
            }
            int index = 0;
            int twain = 0;
            for (int i = 0; i < logChar.Length; ++i)
            {
                if (logChar[i].Contains("color"))
                {
                    //Debug.LogError(preText + "   " + logChar[i]);
                    ++index;
                    if (index % 2 == 0)
                    {
                        logChar[i] = "</color>";
                    }
                    else
                    {
                        if (twain >= targetCol.Count)
                            logChar[i] = "<" + targetCol[targetCol.Count - 1] + ">";
                        else
                            logChar[i] = "<" + targetCol[twain] + ">";
                        twain++;
                    }
                }
                else if (logChar[i].Equals("a href=point") || logChar[i].Equals("/a"))
                {
                    logChar[i] = "<" + logChar[i] + ">";
                }
            }
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < logChar.Length; ++i)
                s.Append(logChar[i]);
            //如果不是成对的 在最后加上结束符
            if (index != 2 * twain)
                s.Append("</color>");
            return s.ToString();
        }

        private string ReturnP(string result)
        {
            char[] arr = result.ToCharArray();
            for (int i = 0; i < arr.Length; ++i)
            {
                if (arr[i] == '>')
                    arr[i] = '<';
                else if (arr[i] == '<')
                    arr[i] = '>';
                else if (arr[i] == '[')
                    arr[i] = ' ';
                else if (arr[i] == ']')
                    arr[i] = ' ';
                else if (arr[i] == '(')
                    arr[i] = ')';
                else if (arr[i] == ')')
                    arr[i] = '(';
            }
            result = new string(arr);
            return result;
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
