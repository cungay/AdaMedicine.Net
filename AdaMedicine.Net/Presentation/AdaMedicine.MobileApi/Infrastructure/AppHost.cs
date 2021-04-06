using Ege.Net;
using Ege.Net.Orm;
using Ege.Net.Data;
using Ege.Net.Api.OpenApi;
using Ege.Net.Text;
using Ege.Net.VirtualPath;
using Funq;
using AdaMedicine.Services;
using Ege.Net.Auth;
using Ege.Net.Caching;
using System.Linq;

namespace AdaMedicine.MobileApi.Infrastructure
{
    public class AppHost : AppHostBase
    {
        public AppHost() : base("Ada Medicine Mobile REST API", typeof(HospitalService).Assembly) { }

        public override void Configure(Container container)
        {
            container.Register<IDbConnectionFactory>(new OrmConnectionFactory(
                AppSettings.GetString("connectionStrings:dev"), SqlServerDialect.Provider));

            container.Register<IAuthRepository>(c => new OrmAuthRepository(c.Resolve<IDbConnectionFactory>())
            {
                UseDistinctRoleTables = true
            });

            //Create UserAuth RDBMS Tables
            container.Resolve<IAuthRepository>().InitSchema();

            //Also store User Sessions in SQL Server
            container.RegisterAs<OrmCacheClient, ICacheClient>();
            container.Resolve<ICacheClient>().InitSchema();

            var base64Key = System.Convert.ToBase64String(AesUtils.CreateKey());
            var privateKey = RsaUtils.CreatePrivateKeyParams(RsaKeyLengths.Bit2048);
            var publicKey = privateKey.ToPublicRsaParameters();
            var privateKeyXml = privateKey.ToPrivateKeyXml();
            var publicKeyXml = privateKey.ToPublicKeyXml();

            // just for testing, create a privateKeyXml on every instance
            Plugins.Add(new AuthFeature(() => new AuthUserSession(),
                new IAuthProvider[]
                {
                    //new JwtAuthProvider(AppSettings) {
                    //    //AuthKeyBase64 = base64Key, //AppSettings.GetString("AuthKeyBase64"),
                    //    //UseTokenCookie = true,
                    //    //CreatePayloadFilter = (payload,session) =>{
                    //    //    payload["CreatedAt"] = session.CreatedAt.ToUnixTime().ToString();
                    //    //},
                    //    //PopulateSessionFilter = (session,payload,req) =>{
                    //    //    session.CreatedAt = long.Parse(payload["CreatedAt"]).FromUnixTime();
                    //    //},
                    //    HashAlgorithm = "RS256",
                    //    PrivateKeyXml = privateKeyXml,
                    //    //PublicKeyXml = publicKeyXml,
                    //    //EncryptPayload = true
                    //},
                    new JwtAuthProvider(AppSettings) { AuthKey = AesUtils.CreateKey() },
                    new CredentialsAuthProvider(AppSettings),
                    new GoogleAuthProvider(AppSettings)
                }));

            Plugins.Add(new RegistrationFeature());

            var authRepo = GetAuthRepository();
            //authRepo.CreateUserAuth(new UserAuth
            //{
            //    Id = 1,
            //    UserName = "iko",
            //    FirstName = "First",
            //    LastName = "Last",
            //    DisplayName = "Display",
            //}, "1");

            AddVirtualFileSources.Add(new FileSystemMapping("img", $"{HostContext.RootDirectory.RealPath}\\sql"));

            SetConfig(new HostConfig
            {
                StrictMode = AppSettings.Get(nameof(HostConfig.StrictMode), false),
                DebugMode = AppSettings.Get(nameof(HostConfig.DebugMode), true),
                HandlerFactoryPath = "api",
                DefaultContentType = MimeTypes.Json,
                ApiVersion = "1.0",
                UseSaltedHash = true,
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
            //Plugins.Add(new RegistrationFeature());

            if (!Config.DebugMode)
            {
                Plugins.Add(new RequestLogsFeature { RequestLogger = new CsvRequestLogger() });
            }

            var feature = Plugins.FirstOrDefault(x => x is SvgFeature);
            Plugins.RemoveAll(x => x is SvgFeature);
        }
    }
}
