using Ege.Net;
using Ege.Net.Orm;
using Ege.Net.Data;
using Ege.Net.Api.OpenApi;
using Ege.Net.Text;
using Ege.Net.VirtualPath;
using Funq;
using AdaMedicine.Services;

namespace AdaMedicine.MobileApi.Infrastructure
{
    public class AppHost : AppHostBase
    {
        public AppHost() : base("Ada Medicine Mobile REST API", typeof(HospitalService).Assembly) { }

        public override void Configure(Container container)
        {
            container.Register<IDbConnectionFactory>(new OrmConnectionFactory(
                AppSettings.GetString("connectionStrings:dev"), SqlServerDialect.Provider));

            AddVirtualFileSources.Add(new FileSystemMapping("img", $"{HostContext.RootDirectory.RealPath}\\sql"));

            SetConfig(new HostConfig
            {
                StrictMode = AppSettings.Get(nameof(HostConfig.StrictMode), false),
                DebugMode = AppSettings.Get(nameof(HostConfig.DebugMode), true),
                HandlerFactoryPath = "api",
                DefaultContentType = MimeTypes.Json,
                ApiVersion = "1.0",
            });

            JsConfig.Init(new Config { TextCase = TextCase.Default, });

            Plugins.Add(new AutoQueryFeature
            {
                MaxLimit = 100,
                IncludeTotal = true,
                EnableAsync = true,
                EnableAutoQueryViewer = true,
            });

            Plugins.Add(new OpenApiFeature());
            Plugins.Add(new PostmanFeature());
            Plugins.Add(new CorsFeature());

            if (!Config.DebugMode)
            {
                Plugins.Add(new RequestLogsFeature { RequestLogger = new CsvRequestLogger() });
            }
        }
    }
}
