﻿using System;
using log4net;
using log4net.Core;

namespace HCL.UBP.WebUI
{
    internal class LoggerForInjection : ILog
    {
        private ILog _log;

        public bool IsDebugEnabled
        {
            get { return Log.IsDebugEnabled; }
        }

        public bool IsErrorEnabled
        {
            get { return Log.IsErrorEnabled; }
        }

        public bool IsFatalEnabled
        {
            get { return Log.IsFatalEnabled; }
        }

        public bool IsInfoEnabled
        {
            get { return Log.IsInfoEnabled; }
        }

        public bool IsWarnEnabled
        {
            get { return Log.IsWarnEnabled; }
        }

        public ILogger Logger
        {
            get { return _log.Logger; }
        }

        private ILog Log
        {
            get
            {
                if (_log == null)
                {
                    var stackTrace = new System.Diagnostics.StackTrace();
                    string callingType = stackTrace.GetFrame(2).GetMethod().DeclaringType.FullName;
                    _log = LogManager.GetLogger(callingType);
                }
                return _log;
            }
        }

        public void Debug(object message)
        {
            Log.Debug(message);
        }

        public void Debug(object message, Exception exception)
        {
            Log.Debug(message, exception);
        }

        public void DebugFormat(string format, params object[] args)
        {
            Log.DebugFormat(format, args);
        }

        public void DebugFormat(string format, object arg0)
        {
            Log.DebugFormat(format, arg0);
        }

        public void DebugFormat(string format, object arg0, object arg1)
        {
            Log.DebugFormat(format, arg0, arg1);
        }

        public void DebugFormat(string format, object arg0, object arg1, object arg2)
        {
            Log.DebugFormat(format, arg0, arg1, arg2);
        }

        public void DebugFormat(IFormatProvider provider, string format, params object[] args)
        {
            Log.DebugFormat(provider, format, args);
        }

        public void Error(object message)
        {
            Log.Error(message);
        }

        public void Error(object message, Exception exception)
        {
            Log.Error(message, exception);
        }

        public void ErrorFormat(string format, params object[] args)
        {
            Log.ErrorFormat(format, args);
        }

        public void ErrorFormat(string format, object arg0)
        {
            Log.ErrorFormat(format, arg0);
        }

        public void ErrorFormat(string format, object arg0, object arg1)
        {
            Log.ErrorFormat(format, arg0, arg1);
        }

        public void ErrorFormat(string format, object arg0, object arg1, object arg2)
        {
            Log.ErrorFormat(format, arg0, arg1, arg2);
        }

        public void ErrorFormat(IFormatProvider provider, string format, params object[] args)
        {
            Log.ErrorFormat(provider, format, args);
        }

        public void Fatal(object message)
        {
            Log.Fatal(message);
        }

        public void Fatal(object message, Exception exception)
        {
            Log.Fatal(message, exception);
        }

        public void FatalFormat(string format, params object[] args)
        {
            Log.FatalFormat(format, args);
        }

        public void FatalFormat(string format, object arg0)
        {
            Log.FatalFormat(format, arg0);
        }

        public void FatalFormat(string format, object arg0, object arg1)
        {
            Log.FatalFormat(format, arg0, arg1);
        }

        public void FatalFormat(string format, object arg0, object arg1, object arg2)
        {
            Log.FatalFormat(format, arg0, arg1, arg2);
        }

        public void FatalFormat(IFormatProvider provider, string format, params object[] args)
        {
            Log.FatalFormat(provider, format, args);
        }

        public void Info(object message)
        {
            Log.Info(message);
        }

        public void Info(object message, Exception exception)
        {
            Log.Info(message, exception);
        }

        public void InfoFormat(string format, params object[] args)
        {
            Log.InfoFormat(format, args);
        }

        public void InfoFormat(string format, object arg0)
        {
            Log.InfoFormat(format, arg0);
        }

        public void InfoFormat(string format, object arg0, object arg1)
        {
            Log.InfoFormat(format, arg0, arg1);
        }

        public void InfoFormat(string format, object arg0, object arg1, object arg2)
        {
            Log.InfoFormat(format, arg0, arg1, arg2);
        }

        public void InfoFormat(IFormatProvider provider, string format, params object[] args)
        {
            Log.InfoFormat(provider, format, args);
        }

        public void Warn(object message)
        {
            Log.Warn(message);
        }

        public void Warn(object message, Exception exception)
        {
            Log.Warn(message, exception);
        }

        public void WarnFormat(string format, params object[] args)
        {
            Log.WarnFormat(format, args);
        }

        public void WarnFormat(string format, object arg0)
        {
            Log.WarnFormat(format, arg0);
        }

        public void WarnFormat(string format, object arg0, object arg1)
        {
            Log.WarnFormat(format, arg0, arg1);
        }

        public void WarnFormat(string format, object arg0, object arg1, object arg2)
        {
            Log.WarnFormat(format, arg0, arg1, arg2);
        }

        public void WarnFormat(IFormatProvider provider, string format, params object[] args)
        {
            Log.WarnFormat(provider, format, args);
        }
    }
}