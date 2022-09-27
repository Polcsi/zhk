namespace Hospital.Helper
{
    class ConvertPhoneNumber
    {
        private string counrtyCode, providerCode;
        private string firstPart, secondPart;
        public static string toHungarianFormat(Phone convertablePhoneNumber)
        {
            ConvertPhoneNumber convertedPhone = new ConvertPhoneNumber();
            convertedPhone.counrtyCode = $"{convertablePhoneNumber.CountryCode}";
            convertedPhone.providerCode = $"{convertablePhoneNumber.ProviderCode}";
            convertedPhone.firstPart = $"{convertablePhoneNumber.FirstPart}";
            convertedPhone.secondPart = $"{convertablePhoneNumber.SecondPart}";

            return string.Format($"{convertablePhoneNumber.CountryCode}/{convertablePhoneNumber.ProviderCode} {convertablePhoneNumber.FirstPart}-{convertablePhoneNumber.SecondPart}");
        }
    }
}
