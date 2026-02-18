namespace AesCryptoTool.Models
{
    public class CryptoViewModel
    {
        public string PlainText { get; set; }
        public string Key { get; set; }
        public string EncryptedText { get; set; }

        public string CipherText { get; set; }
        public string DecryptedText { get; set; }

        public string DefaultKey { get; set; }
    }
}
