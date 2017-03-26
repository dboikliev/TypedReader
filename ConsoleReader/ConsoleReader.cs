﻿using ConsoleReader.Tokenization;
using System;

namespace ConsoleReader
{
    public static class ConsoleReader
    {
        private static readonly Reader _reader = new Reader();
        public static TokenizerOptions TokenizerOptions => _reader.TokenizerOptions;

        public static T Next<T>()
        {
            return _reader.Next<T>(Console.In);
        }
    }
}