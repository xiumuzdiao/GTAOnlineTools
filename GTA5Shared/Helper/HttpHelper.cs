using RestSharp;

namespace GTA5Shared.Helper;

public static class HttpHelper
{
    [DllImport("dnsapi.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool DnsFlushResolverCache();

    private static readonly RestClient client;

    static HttpHelper()
    {
        if (client == null)
        {
            var options = new RestClientOptions()
            {
                MaxTimeout = 5000,
                ThrowOnAnyError = false
            };
            client = new RestClient(options);
        }
    }

    /// <summary>
    /// 获取url内容字符串
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public static async Task<string> DownloadString(string url)
    {
        var request = new RestRequest(url);
        var response = await client.ExecuteGetAsync(request);

        if (response.StatusCode == HttpStatusCode.OK)
            return response.Content;

        return string.Empty;
    }

    /// <summary>
    /// 刷新DNS缓存
    /// </summary>
    public static void FlushDNSCache()
    {
        DnsFlushResolverCache();
    }
}
