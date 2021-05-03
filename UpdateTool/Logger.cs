using System;
using System.IO;
using System.Globalization;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using NLog;

namespace UpdateTool
{
    enum enLoggerType
    {
        TRACE,
        DEBUG,
        INFO,
        WARN,
        ERROR,
        FATAL
    }

    class Logger
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public static void Debug(string strMsg,
            [System.Runtime.CompilerServices.CallerMemberName] string strMemberName = "",
            [System.Runtime.CompilerServices.CallerFilePath] string strSrcFilePath = "",
            [System.Runtime.CompilerServices.CallerLineNumber] int nSourceLineNumber = 0)
        {

            OutputToDebugLog(enLoggerType.DEBUG, strMsg, strMemberName, strSrcFilePath, nSourceLineNumber);
        }

        public static void Info(string strMsg,
            [System.Runtime.CompilerServices.CallerMemberName] string strMemberName = "",
            [System.Runtime.CompilerServices.CallerFilePath] string strSrcFilePath = "",
            [System.Runtime.CompilerServices.CallerLineNumber] int nSourceLineNumber = 0)
        {
            OutputToDebugLog(enLoggerType.INFO, strMsg, strMemberName, strSrcFilePath, nSourceLineNumber);
        }

        public static void Warn(string strMsg,
            [System.Runtime.CompilerServices.CallerMemberName] string strMemberName = "",
            [System.Runtime.CompilerServices.CallerFilePath] string strSrcFilePath = "",
            [System.Runtime.CompilerServices.CallerLineNumber] int nSourceLineNumber = 0)
        {
            OutputToDebugLog(enLoggerType.WARN, strMsg, strMemberName, strSrcFilePath, nSourceLineNumber);
        }

        public static void Error(string strMsg,
            [System.Runtime.CompilerServices.CallerMemberName] string strMemberName = "",
            [System.Runtime.CompilerServices.CallerFilePath] string strSrcFilePath = "",
            [System.Runtime.CompilerServices.CallerLineNumber] int nSourceLineNumber = 0)
        {
            OutputToDebugLog(enLoggerType.ERROR, strMsg, strMemberName, strSrcFilePath, nSourceLineNumber);
        }

        public static void OutputToDebugLog(
            enLoggerType logType,
            string strMsg,
            string strMemberName,
            string strSrcFilePath,
            int nSourceLineNumber = 0)
        {
            var culture = new CultureInfo("en-US");
            string strFormat = "yyyy/MM/dd HH:mm:ss.fff";

            string strFilename = Path.GetFileName(strSrcFilePath);
            string strNowTime = DateTime.Now.ToString(strFormat, culture);

            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);

            string strCurrentMethodName = sf.GetMethod().Name;

            if (strCurrentMethodName.Length < 5) strCurrentMethodName += " ";

            string strOutput = string.Format("{0} {1} - <{2}({3})({4})><{5}>",
                strNowTime, strCurrentMethodName, strFilename, nSourceLineNumber, strMemberName, strMsg);

            if (logType == enLoggerType.TRACE)
            {
                logger.Trace(strOutput);
            }
            else if (logType == enLoggerType.DEBUG)
            {
                logger.Debug(strOutput);
            }
            else if (logType == enLoggerType.INFO)
            {
                logger.Info(strOutput);
            }
            else if (logType == enLoggerType.WARN)
            {
                logger.Warn(strOutput);
            }
            else if (logType == enLoggerType.ERROR)
            {
                logger.Error(strOutput);
            }
            else
            {
                logger.Fatal(strOutput);
            }
        }
    }
}
