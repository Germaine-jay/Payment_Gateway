﻿using Payment_Gateway.BLL.Infrastructure.Otp;
using Payment_Gateway.Models.Extensions;
using System.Text;

namespace Payment_Gateway.BLL.Infrastructure.Security
{
    public class CacheKeySelector
    {
        public static string OtpCodeCacheKey(string userId, OtpOperation operation)
        {
            return SHA256Hasher.Hash($"{CacheKeyPrefix.OtpCode}_{userId}_{operation}");
        }

        public static string AccountLockoutCacheKey(string userId)
        {

            return SHA256Hasher.Hash($"{CacheKeyPrefix.AccountLockout}_{userId}");
        }


        public static string GenerateToken()
        {
            Random generator = new Random();
            string token = generator.Next(0, 999999).ToString("D6");
            return token;
        }


        public static string GenerateUniqueOtpCacheKey(string userId, OtpOperation operation)
        {
            StringBuilder build = new StringBuilder();
            Encoding encoding = Encoding.ASCII;
            Encoding enc = Encoding.UTF8;

            var user = Convert.ToBase64String(encoding.GetBytes(userId));
            var ops = Convert.ToBase64String(enc.GetBytes(operation.ToString()));
            var extra = Convert.ToBase64String(enc.GetBytes("3d8kb8MygLe5PyKRfOUXPXspOF"));

            build.Append(ops);
            build.Append(user);
            build.Append(extra);

            return build.ToString();
        }


    }
}


