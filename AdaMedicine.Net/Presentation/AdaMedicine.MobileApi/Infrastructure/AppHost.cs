using Ege.Net;
using Ege.Net.Orm;
using Ege.Net.Data;
using Ege.Net.Api.OpenApi;
using Ege.Net.Text;
using Funq;
using AdaMedicine.Services;

namespace AdaMedicine.MobileApi.Infrastructure
{
    public class AppHost : AppHostBase
    {
        public AppHost() : base("Ada Medicine Mobile REST API", typeof(HospitalService).Assembly)
        {
        }

        public override void Configure(Container container)
        {
            container.Register<IDbConnectionFactory>(new OrmConnectionFactory(AppSettings.GetString("connectionStrings:dev"), SqlServerDialect.Provider));

            SetConfig(new HostConfig
            {
                HandlerFactoryPath = "api",
                DebugMode = AppSettings.Get(nameof(HostConfig.DebugMode), true),
                //DefaultRedirectPath = "/metadata",
                DefaultContentType = MimeTypes.Json,
            });

            JsConfig.Init(new Config
            {
                TextCase = TextCase.Default,
                //ExcludeDefaultValues = true,
                //IncludeNullValues = true,
                //IncludeNullValuesInDictionaries = true
            });

            Plugins.Add(new AutoQueryFeature
            {
                MaxLimit = 100,
                IncludeTotal = true,
                EnableAsync = true,
            });

            Plugins.Add(new OpenApiFeature());
            Plugins.Add(new PostmanFeature());
            Plugins.Add(new CorsFeature());
            Plugins.Add(new RequestLogsFeature { RequestLogger = new CsvRequestLogger() });
        }
    }
}
