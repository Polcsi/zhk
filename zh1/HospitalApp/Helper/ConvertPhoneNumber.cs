using System;

namespace HospitalApp.Helper
{
    class ConvertPhoneNumber
    {
        private string countryCode, providerCode;
        private string firstPart, secondPart;
        public static string toHungarianFormat(Phone convertablePhoneNumber)
        {
            ConvertPhoneNumber convertedPhoneNumber = new ConvertPhoneNumber();
            convertedPhoneNumber.countryCode = Convert.ToString(convertablePhoneNumber.CountryCode);
            convertedPhoneNumber.providerCode = Convert.ToString(convertablePhoneNumber.ProviderCode);
            convertedPhoneNumber.firstPart = Convert.ToString(convertablePhoneNumber.FirstPart);
            convertedPhoneNumber.secondPart = Convert.ToString(convertablePhoneNumber.SecondPart);

            return string.Format($"{convertedPhoneNumber.countryCode}/{convertedPhoneNumber.providerCode} {convertedPhoneNumber.firstPart}-{convertedPhoneNumber.secondPart}");
        }
    }
}
