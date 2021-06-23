using System;
namespace UnityEngineUIExpansion
{
    public enum EnglishNumbers
    {
        Zero = 0x0030,
        One = 0x0031,
        Two = 0x0032,
        Three = 0x0033,
        Four = 0x0034,
        Five = 0x0035,
        Six = 0x0036,
        Seven = 0x0037,
        Eight = 0x0038,
        Nine = 0x0039
    }
    public enum FarsiNumbers
    {
        Zero = 0x6F0,
        One = 0x6F1,
        Two = 0x6F2,
        Three = 0x6F3,
        Four = 0x6F4,
        Five = 0x6F5,
        Six = 0x6F6,
        Seven = 0x6F7,
        Eight = 0x6F8,
        Nine = 0x6F9
    }
    public enum GeneralLetters
    {
        Hamza = 0x0621,
        Alef = 0x0627,
        AlefHamza = 0x0623,
        WawHamza = 0x0624,
        AlefMaksoor = 0x0625,
        AlefMaksura = 0x649,
        HamzaNabera = 0x0626,
        Ba = 0x0628,
        Ta = 0x062A,
        Tha2 = 0x062B,
        Jeem = 0x062C,
        H7aa = 0x062D,
        Khaa2 = 0x062E,
        Dal = 0x062F,
        Thal = 0x0630,
        Ra2 = 0x0631,
        Zeen = 0x0632,
        Seen = 0x0633,
        Sheen = 0x0634,
        S9a = 0x0635,
        Dha = 0x0636,
        T6a = 0x0637,
        T6ha = 0x0638,
        Ain = 0x0639,
        Gain = 0x063A,
        Fa = 0x0641,
        Gaf = 0x0642,
        Kaf = 0x0643,
        Lam = 0x0644,
        Meem = 0x0645,
        Noon = 0x0646,
        Ha = 0x0647,
        Waw = 0x0648,
        Ya = 0x064A,
        AlefMad = 0x0622,
        TaMarboota = 0x0629,
        PersianYa = 0x6CC,
        PersianPe = 0x067E,
        PersianChe = 0x0686,
        PersianZe = 0x0698,
        PersianGaf = 0x06AF,
        PersianGaf2 = 0x06A9,
        ArabicTatweel = 0x640,
        ZeroWidthNoJoiner = 0x200C
    }

    internal enum IsolatedLetters
    {
        Hamza = 0xFE80,
        Alef = 0xFE8D,
        AlefHamza = 0xFE83,
        WawHamza = 0xFE85,
        AlefMaksoor = 0xFE87,
        AlefMaksura = 0xFEEF,
        HamzaNabera = 0xFE89,
        Ba = 0xFE8F,
        Ta = 0xFE95,
        Tha2 = 0xFE99,
        Jeem = 0xFE9D,
        H7aa = 0xFEA1,
        Khaa2 = 0xFEA5,
        Dal = 0xFEA9,
        Thal = 0xFEAB,
        Ra2 = 0xFEAD,
        Zeen = 0xFEAF,
        Seen = 0xFEB1,
        Sheen = 0xFEB5,
        S9a = 0xFEB9,
        Dha = 0xFEBD,
        T6a = 0xFEC1,
        T6ha = 0xFEC5,
        Ain = 0xFEC9,
        Gain = 0xFECD,
        Fa = 0xFED1,
        Gaf = 0xFED5,
        Kaf = 0xFED9,
        Lam = 0xFEDD,
        Meem = 0xFEE1,
        Noon = 0xFEE5,
        Ha = 0xFEE9,
        Waw = 0xFEED,
        Ya = 0xFEF1,
        AlefMad = 0xFE81,
        TaMarboota = 0xFE93,
        PersianYa = 0xFBFC,
        PersianPe = 0xFB56,
        PersianChe = 0xFB7A,
        PersianZe = 0xFB8A,
        PersianGaf = 0xFB92,
        PersianGaf2 = 0xFB8E

    }

    public enum HinduNumbers
    {
        Zero = 0x0660,
        One = 0x0661,
        Two = 0x0662,
        Three = 0x0663,
        Four = 0x0664,
        Five = 0x0665,
        Six = 0x0666,
        Seven = 0x0667,
        Eight = 0x0668,
        Nine = 0x0669
    }

    public enum TashkeelCharacters
    {
        Fathan = 0x064B,
        Dammatan = 0x064C,
        Kasratan = 0x064D,
        Fatha = 0x064E,
        Damma = 0x064F,
        Kasra = 0x0650,
        Shadda = 0x0651,
        Sukun = 0x0652,
        MaddahAbove = 0x0653,
        SuperscriptAlef = 0x670,
        ShaddaWithDammatanIsolatedForm = 0xFC5E,
        ShaddaWithKasratanIsolatedForm = 0xFC5F,
        ShaddaWithFathaIsolatedForm = 0xFC60,
        ShaddaWithDammaIsolatedForm = 0xFC61,
        ShaddaWithKasraIsolatedForm = 0xFC62,
        ShaddaWithSuperscriptAlefIsolatedForm = 0xFC63
    }

    public static class TextUtils
    {
        // Every English character is between these two
        private const char UpperCaseA = (char)0x41;
        private const char LowerCaseZ = (char)0x7A;

        public static bool IsPunctuation(char ch)
        {
            throw new NotImplementedException();
        }

        public static bool IsNumber(char ch, bool preserverNumbers, bool farsi)
        {
            if (preserverNumbers)
                return IsEnglishNumber(ch);

            if (farsi)
                return IsFarsiNumber(ch);

            return IsHinduNumber(ch);
        }

        public static bool IsEnglishNumber(char ch)
        {
            return ch >= (char)EnglishNumbers.Zero && ch <= (char)EnglishNumbers.Nine;
        }

        public static bool IsFarsiNumber(char ch)
        {
            return ch >= (char)FarsiNumbers.Zero && ch <= (char)FarsiNumbers.Nine;
        }

        public static bool IsHinduNumber(char ch)
        {
            return ch >= (char)HinduNumbers.Zero && ch <= (char)HinduNumbers.Nine;
        }

        public static bool IsEnglishLetter(char ch)
        {
            return ch >= UpperCaseA && ch <= LowerCaseZ;
        }


        /// <summary>
        ///     Checks if the character is supported RTL character.
        /// </summary>
        /// <param name="ch">Character to check</param>
        /// <returns><see langword="true" /> if character is supported. otherwise <see langword="false" /></returns>
        public static bool IsRTLCharacter(char ch)
        {
            /*
             * Other shapes of each letter comes right after the isolated form.
             * That's why we add 3 to the isolated letter to cover every shape the letter
             */

            if (ch >= (char)IsolatedLetters.Hamza && ch <= (char)IsolatedLetters.Hamza + 3)
            {
                return true;
            }

            if (ch >= (char)IsolatedLetters.Alef && ch <= (char)IsolatedLetters.Alef + 3)
            {
                return true;
            }

            if (ch >= (char)IsolatedLetters.AlefHamza &&
                ch <= (char)IsolatedLetters.AlefHamza + 3)
            {
                return true;
            }

            if (ch >= (char)IsolatedLetters.WawHamza && ch <= (char)IsolatedLetters.WawHamza + 3)
            {
                return true;
            }

            if (ch >= (char)IsolatedLetters.AlefMaksoor &&
                ch <= (char)IsolatedLetters.AlefMaksoor + 3)
            {
                return true;
            }

            if (ch >= (char)IsolatedLetters.AlefMaksura &&
                ch <= (char)IsolatedLetters.AlefMaksura + 3)
            {
                return true;
            }

            if (ch >= (char)IsolatedLetters.HamzaNabera &&
                ch <= (char)IsolatedLetters.HamzaNabera + 3)
            {
                return true;
            }

            if (ch >= (char)IsolatedLetters.Ba && ch <= (char)IsolatedLetters.Ba + 3)
            {
                return true;
            }

            if (ch >= (char)IsolatedLetters.Ta && ch <= (char)IsolatedLetters.Ta + 3)
            {
                return true;
            }

            if (ch >= (char)IsolatedLetters.Tha2 && ch <= (char)IsolatedLetters.Tha2 + 3)
            {
                return true;
            }

            if (ch >= (char)IsolatedLetters.Jeem && ch <= (char)IsolatedLetters.Jeem + 3)
            {
                return true;
            }

            if (ch >= (char)IsolatedLetters.H7aa && ch <= (char)IsolatedLetters.H7aa + 3)
            {
                return true;
            }

            if (ch >= (char)IsolatedLetters.Khaa2 && ch <= (char)IsolatedLetters.Khaa2 + 3)
            {
                return true;
            }

            if (ch >= (char)IsolatedLetters.Dal && ch <= (char)IsolatedLetters.Dal + 3)
            {
                return true;
            }

            if (ch >= (char)IsolatedLetters.Thal && ch <= (char)IsolatedLetters.Thal + 3)
            {
                return true;
            }

            if (ch >= (char)IsolatedLetters.Ra2 && ch <= (char)IsolatedLetters.Ra2 + 3)
            {
                return true;
            }

            if (ch >= (char)IsolatedLetters.Zeen && ch <= (char)IsolatedLetters.Zeen + 3)
            {
                return true;
            }

            if (ch >= (char)IsolatedLetters.Seen && ch <= (char)IsolatedLetters.Seen + 3)
            {
                return true;
            }

            if (ch >= (char)IsolatedLetters.Sheen && ch <= (char)IsolatedLetters.Sheen + 3)
            {
                return true;
            }

            if (ch >= (char)IsolatedLetters.S9a && ch <= (char)IsolatedLetters.S9a + 3)
            {
                return true;
            }

            if (ch >= (char)IsolatedLetters.Dha && ch <= (char)IsolatedLetters.Dha + 3)
            {
                return true;
            }

            if (ch >= (char)IsolatedLetters.T6a && ch <= (char)IsolatedLetters.T6a + 3)
            {
                return true;
            }

            if (ch >= (char)IsolatedLetters.T6ha && ch <= (char)IsolatedLetters.T6ha + 3)
            {
                return true;
            }

            if (ch >= (char)IsolatedLetters.Ain && ch <= (char)IsolatedLetters.Ain + 3)
            {
                return true;
            }

            if (ch >= (char)IsolatedLetters.Gain && ch <= (char)IsolatedLetters.Gain + 3)
            {
                return true;
            }

            if (ch >= (char)IsolatedLetters.Fa && ch <= (char)IsolatedLetters.Fa + 3)
            {
                return true;
            }

            if (ch >= (char)IsolatedLetters.Gaf && ch <= (char)IsolatedLetters.Gaf + 3)
            {
                return true;
            }

            if (ch >= (char)IsolatedLetters.Kaf && ch <= (char)IsolatedLetters.Kaf + 3)
            {
                return true;
            }

            if (ch >= (char)IsolatedLetters.Lam && ch <= (char)IsolatedLetters.Lam + 3)
            {
                return true;
            }

            if (ch >= (char)IsolatedLetters.Meem && ch <= (char)IsolatedLetters.Meem + 3)
            {
                return true;
            }

            if (ch >= (char)IsolatedLetters.Noon && ch <= (char)IsolatedLetters.Noon + 3)
            {
                return true;
            }

            if (ch >= (char)IsolatedLetters.Ha && ch <= (char)IsolatedLetters.Ha + 3)
            {
                return true;
            }

            if (ch >= (char)IsolatedLetters.Waw && ch <= (char)IsolatedLetters.Waw + 3)
            {
                return true;
            }

            if (ch >= (char)IsolatedLetters.Ya && ch <= (char)IsolatedLetters.Ya + 3)
            {
                return true;
            }

            if (ch >= (char)IsolatedLetters.AlefMad && ch <= (char)IsolatedLetters.AlefMad + 3)
            {
                return true;
            }

            if (ch >= (char)IsolatedLetters.TaMarboota &&
                ch <= (char)IsolatedLetters.TaMarboota + 3)
            {
                return true;
            }

            if (ch >= (char)IsolatedLetters.PersianPe &&
                ch <= (char)IsolatedLetters.PersianPe + 3)
            {
                return true;
            }

            if (ch >= (char)IsolatedLetters.PersianYa &&
                ch <= (char)IsolatedLetters.PersianYa + 3)
            {
                return true;
            }

            if (ch >= (char)IsolatedLetters.PersianChe &&
                ch <= (char)IsolatedLetters.PersianChe + 3)
            {
                return true;
            }

            if (ch >= (char)IsolatedLetters.PersianZe &&
                ch <= (char)IsolatedLetters.PersianZe + 3)
            {
                return true;
            }

            if (ch >= (char)IsolatedLetters.PersianGaf &&
                ch <= (char)IsolatedLetters.PersianGaf + 3)
            {
                return true;
            }

            if (ch >= (char)IsolatedLetters.PersianGaf2 &&
                ch <= (char)IsolatedLetters.PersianGaf2 + 3)
            {
                return true;
            }

            // Special Lam Alef
            if (ch == 0xFEF3)
            {
                return true;
            }

            if (ch == 0xFEF5)
            {
                return true;
            }

            if (ch == 0xFEF7)
            {
                return true;
            }

            if (ch == 0xFEF9)
            {
                return true;
            }

            switch (ch)
            {
                case (char)GeneralLetters.Hamza:
                case (char)GeneralLetters.Alef:
                case (char)GeneralLetters.AlefHamza:
                case (char)GeneralLetters.WawHamza:
                case (char)GeneralLetters.AlefMaksoor:
                case (char)GeneralLetters.AlefMaksura:
                case (char)GeneralLetters.HamzaNabera:
                case (char)GeneralLetters.Ba:
                case (char)GeneralLetters.Ta:
                case (char)GeneralLetters.Tha2:
                case (char)GeneralLetters.Jeem:
                case (char)GeneralLetters.H7aa:
                case (char)GeneralLetters.Khaa2:
                case (char)GeneralLetters.Dal:
                case (char)GeneralLetters.Thal:
                case (char)GeneralLetters.Ra2:
                case (char)GeneralLetters.Zeen:
                case (char)GeneralLetters.Seen:
                case (char)GeneralLetters.Sheen:
                case (char)GeneralLetters.S9a:
                case (char)GeneralLetters.Dha:
                case (char)GeneralLetters.T6a:
                case (char)GeneralLetters.T6ha:
                case (char)GeneralLetters.Ain:
                case (char)GeneralLetters.Gain:
                case (char)GeneralLetters.Fa:
                case (char)GeneralLetters.Gaf:
                case (char)GeneralLetters.Kaf:
                case (char)GeneralLetters.Lam:
                case (char)GeneralLetters.Meem:
                case (char)GeneralLetters.Noon:
                case (char)GeneralLetters.Ha:
                case (char)GeneralLetters.Waw:
                case (char)GeneralLetters.Ya:
                case (char)GeneralLetters.AlefMad:
                case (char)GeneralLetters.TaMarboota:
                case (char)GeneralLetters.PersianPe:
                case (char)GeneralLetters.PersianChe:
                case (char)GeneralLetters.PersianZe:
                case (char)GeneralLetters.PersianGaf:
                case (char)GeneralLetters.PersianGaf2:
                case (char)GeneralLetters.PersianYa:
                case (char)GeneralLetters.ArabicTatweel:
                case (char)GeneralLetters.ZeroWidthNoJoiner:
                    return true;
            }

            return false;
        }

        /// <summary>
        ///     Checks if the input string starts with supported RTL character or not.
        /// </summary>
        /// <returns><see langword="true" /> if input is RTL. otherwise <see langword="false" /></returns>
        public static bool IsRTLInput(string input)
        {
            bool insideTag = false;
            bool result = false;
            foreach (char character in input)
            {
                switch (character)
                {
                    case '<':
                        insideTag = true;
                        continue;
                    case '>':
                        insideTag = false;
                        continue;

                    // Arabic Tashkeel
                    case (char)TashkeelCharacters.Fathan:
                    case (char)TashkeelCharacters.Dammatan:
                    case (char)TashkeelCharacters.Kasratan:
                    case (char)TashkeelCharacters.Fatha:
                    case (char)TashkeelCharacters.Damma:
                    case (char)TashkeelCharacters.Kasra:
                    case (char)TashkeelCharacters.Shadda:
                    case (char)TashkeelCharacters.Sukun:
                    case (char)TashkeelCharacters.MaddahAbove:
                        return true;
                }

                if (insideTag)
                {
                    continue;
                }

                if (char.IsLetter(character))
                {
                    if (!result)
                        result = IsRTLCharacter(character);
                }
            }

            return result;
        }
    }
}