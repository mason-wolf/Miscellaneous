
        static readonly string[] SizeSuffixes = {
            "bytes",
            "KB",
            "MB",
            "GB",
            "TB"
        };

        // convert bytes to megabytes, kilobytes, etc.
        static string SizeSuffix(Int64 value)
        {
            if (value < 0)
            {
                return "-" + SizeSuffix(-value);
            }

            if (value == 0)
            {
                return "0.0 bytes";
            }

            int mag = (int)Math.Log(value, 1024);
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));

            if (Math.Round(adjustedSize, 1) >= 1000)
            {
                mag += 1;
                adjustedSize /= 1024;
            }

            return string.Format("{0:n" + 1 + "} {1}",
                adjustedSize,
                SizeSuffixes[mag]);
        }
