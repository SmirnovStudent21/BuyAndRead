using System;

namespace BuyAndRead.Services
{
    public class PromocodeGenerator
    {
        public static Guid CodeGen()
        {
            Guid code;
            code = Guid.NewGuid();
            return code;
        }
    }
}