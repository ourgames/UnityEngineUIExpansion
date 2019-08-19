using System;
using UnityEngineUIExpansion;
namespace UnityEngine.UI
{
    [AddComponentMenu("UI/BUI Text", 10)]
    public class BUIText : Text
    {
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
                }
            }
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
