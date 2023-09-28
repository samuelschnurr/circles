namespace Io.Schnurr.Circles.App.Utils;

public static class Helpers
{
    public static long MaxFileSize => 2500 * 1024; // 2,5 Mb

    public static bool HasNull(params dynamic?[] nullableValues)
    {
#pragma warning disable S3267 // Loops should be simplified with "LINQ" expressions
        foreach (var value in nullableValues)
        {
            if (value is null)
            {
                return true;
            }
        }
#pragma warning restore S3267 // Loops should be simplified with "LINQ" expressions
        return false;
    }

    public static async Task<string> ConvertBytesToBase64Async(byte[] bytes, string mimeType)
    {
        var base64Bytes = await Task.Run(() => Convert.ToBase64String(bytes));
        var base64String = string.Format("data:{0};base64,{1}", mimeType, base64Bytes);
        return base64String;
    }
}