using System;

namespace EnrichDomain.RDM.Models
{
    public class Email
    {
        private const string MailDomain = "@gmail.com";
        private readonly string _email;

        private Email(string mail)
        {
            if (string.IsNullOrEmpty(mail))
                throw new ArgumentNullException(mail);

            CheckDomain(mail);
            _email = mail;
        }

        public static Email Create(string mail)
        {
            return new(mail);
        }

        private static void CheckDomain(string mail)
        {
            if (!mail.EndsWith(MailDomain))
            {
                throw new ArgumentException("InvalidMailDomain");
            }
        }

        public override string ToString()
        {
            return _email;
        }
    }
}
