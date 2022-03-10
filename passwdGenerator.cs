using System;


namespace Iksoftware
{
    /// <summary>
    /// Provide methods to generate password and UUID.
    /// </summary>
    static class CredentialGenerator
    {
        static string minuscules = "abcdefghijklmnopqrstuvwxyz";
        static string majuscules = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        static string specialsCaracters = "-_*^.!()";
        static string chiffers = "012345789";

        /// <summary>
        /// Generate randon password. The format is parametable.
        /// </summary>
        /// <param name="length">Specify the length of the password. Default 8 caracters.</param>
        /// <param name="lower">Include lower caracters. Default true.</param>
        /// <param name="upper">Include upper caracters. Default true.</param>
        /// <param name="chiffres">Include chiffer caracters. Default true.</param>
        /// <param name="specials">Include specials caracters. Default false.</param>
        /// <returns>string</returns>
        public static string GeneratePassword(
            int length = 8,
            bool lower = true,
            bool upper = true,
            bool chiffres = true,
            bool specials = false
        )
        {

            string pool = "";

            if (lower)
            {
                pool += minuscules;
            }

            if (upper)
            {
                pool += majuscules;
            }

            if (chiffres)
            {
                pool += chiffers;
            }

            if (specials)
            {
                pool += specialsCaracters;
            }


            string pwdGenerated = "";

            Random rand = new Random();
            for (int i = 0; i < length; i++)
            {
                int idx = rand.Next(0, pool.Length);
                pwdGenerated += pool[idx];
            }
            return pwdGenerated;
        }

        /// <summary>
        /// Generate UUID.
        /// </summary>
        /// <param name="dash">Include dash. Default true.</param>
        /// <returns>string</returns>
        public static string GenerateUUID(bool dash=true)
        {
            Guid token = Guid.NewGuid();
            string tokenAsString = token.ToString();
            if (dash)
            {
                return tokenAsString;
            } else
            {
                return tokenAsString.Replace("-", "");
            }
        }
    }
}
