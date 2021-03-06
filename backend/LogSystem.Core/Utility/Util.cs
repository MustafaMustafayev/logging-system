﻿using System;
using System.Security.Cryptography;
using System.Text;

namespace LogSystem.Core.Utility
{
    public class Util : IUtil
    {
        public string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                string passwordHash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                return passwordHash;
            }
        }
    }
}
