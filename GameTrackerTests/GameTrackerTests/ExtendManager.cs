using System;
using System.Collections.Generic;
using System.Text;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace GameTrackerTests
{
    public static class ExtentManager
    {
        public static ExtentReports extent;

        static ExtentManager()
        {
            var reporter =
                new ExtentSparkReporter(
                    "TestReport.html"
                );

            extent = new ExtentReports();

            extent.AttachReporter(
                reporter
            );
        }
    }
}