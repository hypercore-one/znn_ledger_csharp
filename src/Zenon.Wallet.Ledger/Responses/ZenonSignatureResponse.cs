﻿namespace Zenon.Wallet.Ledger.Responses
{
    public class ZenonSignatureResponse : ResponseBase
    {
        public byte[]? SignatureData { get; }

        public string? Signature { get; }

        public override int ReturnCode
        {
            get
            {
                if (base.ReturnCode != StatusCode.Success)
                    return base.ReturnCode;

                if (Data == null || Data.Length != 67)
                    return StatusCode.WrongResponseLength;

                return base.ReturnCode;
            }
        }

        public ZenonSignatureResponse(byte[] data)
            : base(data)
        {
            if (!IsSuccess)
            {
                return;
            }

            using (var memoryStream = new MemoryStream(data))
            {
                var size = memoryStream.ReadByte();
                SignatureData = memoryStream.ReadAllBytes(size);
                Signature = Convert.ToHexString(SignatureData);
            }
        }
    }
}
