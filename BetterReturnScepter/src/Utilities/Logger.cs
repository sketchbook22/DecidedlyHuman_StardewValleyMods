﻿using System;
using StardewModdingAPI;

namespace BetterReturnScepter.Utilities
{
    public class Logger
    {
        private IMonitor monitor;
        private string logPrefix = "";

        public Logger(IMonitor m)
        {
            monitor = m;
        }

        private void Log(string logMessage, string logPrefix, LogLevel logLevel)
        {
            monitor.Log(logPrefix + logMessage, logLevel);
        }

        public void Log(string logMessage, LogLevel logLevel = LogLevel.Info)
        {
            this.Log(logMessage, logPrefix, logLevel);
        }

        public void Trace(string logMessage)
        {
            this.Log(logMessage, logPrefix, LogLevel.Warn);
        }

        public void Warn(string logMessage)
        {
            this.Log(logMessage, logPrefix, LogLevel.Warn);
        }

        public void Error(string logMessage)
        {
            this.Log(logMessage, logPrefix, LogLevel.Error);
        }

        public void Exception(Exception e)
        {
            monitor.Log($"{logPrefix} Exception: {e.Message}", LogLevel.Error);
            monitor.Log($"{logPrefix} Full exception data: \n{e.Data}", LogLevel.Error);
        }
    }
}