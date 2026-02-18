using Microsoft.AspNetCore.Mvc;
using AesCryptoTool.Services;
using AesCryptoTool.Models;

namespace AesCryptoTool.Controllers
{
    public class CryptoController : Controller
    {
        private readonly AesService _aesService = new();

        public IActionResult Index()
        {
            return View(new CryptoViewModel
            {
                DefaultKey = _aesService.GenerateRandomKey()
            });
        }

        [HttpPost]
        public IActionResult Encrypt(string PlainText, string Key)
        {
            Console.WriteLine($"Text: {PlainText}");
            Console.WriteLine($"Key: {Key}");

            var model = new CryptoViewModel
            {
                PlainText = PlainText,
                Key = Key,
                EncryptedText = _aesService.Encrypt(PlainText, Key),
                DefaultKey = _aesService.GenerateRandomKey()
            };

            return View("Index", model);
        }

        [HttpPost]
        public IActionResult Decrypt(string CipherText, string Key)
        {
            var model = new CryptoViewModel
            {
                CipherText = CipherText,
                Key = Key,
                DecryptedText = _aesService.Decrypt(CipherText, Key),
                DefaultKey = _aesService.GenerateRandomKey()
            };

            return View("Index", model);
        }
    }
}
