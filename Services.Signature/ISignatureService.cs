using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Signature
{
    public interface ISignatureService
    {
        Task<List<SignatureService>> GenerateSignature();
        //public static string GenerateSignature();
        //static string GenerateSignature(string dataToSign, string certificatePath, string certificatePass);
    }
}
