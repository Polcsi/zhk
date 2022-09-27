using System;

namespace House.Helper
{
    class ConvertPhoneNumber
    {
        private string countryCode, providerCode;
        private string firstPart, secondPart;
        public static string toHungarianFormat(Phone phoneNumber)
        {
            ConvertPhoneNumber convertedPhoneNumber = new ConvertPhoneNumber();
            convertedPhoneNumber.countryCode = $"{phoneNumber.CountryCode}";
            convertedPhoneNumber.providerCode = $"{phoneNumber.ProviderCode}";
            convertedPhoneNumber.firstPart = $"{phoneNumber.FirstPart}";
            convertedPhoneNumber.secondPart = $"{phoneNumber.SecondPart}";

            return String.Format($"{convertedPhoneNumber.countryCode}/{convertedPhoneNumber.providerCode} {convertedPhoneNumber.firstPart}-{convertedPhoneNumber.secondPart}");
        }
    }
}
