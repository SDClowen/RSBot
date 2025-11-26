using System.Text;

namespace RSBot.Alchemy.Extension;

internal static class StringExtension
{
    #region Methods

    public static string JoymaxFormat<T1>(this string unformatted, T1 valA)
    {
        var stringBulder = new StringBuilder(unformatted);
        stringBulder = stringBulder.Replace("%d", "%s");

        stringBulder = stringBulder.Replace("%s", valA.ToString(), 0, stringBulder.ToString().IndexOf("%s") + 2);

        return stringBulder.ToString();
    }

    public static string JoymaxFormat<T1, T2>(this string unformatted, T1 valA, T2 valB)
    {
        var stringBulder = new StringBuilder(unformatted);
        stringBulder = stringBulder.Replace("%d", "%s");

        stringBulder = stringBulder.Replace("%s", valA.ToString(), 0, stringBulder.ToString().IndexOf("%s") + 2);
        stringBulder = stringBulder.Replace("%s", valB.ToString(), 0, stringBulder.ToString().IndexOf("%s") + 2);

        return stringBulder.ToString();
    }

    public static string JoymaxFormat<T1, T2, T3>(this string unformatted, T1 valA, T2 valB, T3 valC)
    {
        var stringBulder = new StringBuilder(unformatted);
        stringBulder = stringBulder.Replace("%d", "%s");

        stringBulder = stringBulder.Replace("%s", valA.ToString(), 0, stringBulder.ToString().IndexOf("%s") + 2);
        stringBulder = stringBulder.Replace("%s", valB.ToString(), 0, stringBulder.ToString().IndexOf("%s") + 2);
        stringBulder = stringBulder.Replace("%s", valC.ToString(), 0, stringBulder.ToString().IndexOf("%s") + 2);

        return stringBulder.ToString();
    }

    #endregion Methods
}
