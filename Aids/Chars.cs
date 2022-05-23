namespace Rakendus.Aids
{
   public static class Chars
    {
        public static bool IsNameChar(this char x) => char.IsLetterOrDigit(x) || char.IsDigit(x) || x == '`';
        public static bool IsFullNameChar(this char x) => IsNameChar(x) || x == '.';
    }
}


