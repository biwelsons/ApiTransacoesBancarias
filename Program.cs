using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;


namespace ApiTransacoesBancarias
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {       
                    webBuilder.ConfigureServices((hostContext, services) =>
                    {
                        services.AddControllers();

                        {
                        services.AddCors();
                        services.AddControllers();

                        var key = Encoding.ASCII.GetBytes(Settings.secretKey);
                        
                        services.AddAuthentication(x =>
                        {
                            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                        })
                        .AddJwtBearer(x =>
                        {
                            x.RequireHttpsMetadata = false;
                            x.SaveToken = true;
                            x.TokenValidationParameters = new TokenValidationParameters
                            {
                                ValidateIssuerSigningKey = true,
                                IssuerSigningKey = new SymmetricSecurityKey(key),
                                ValidateIssuer = false,
                                ValidateAudience = false
                            };
                        });
                    }

                        services.AddDbContext<AppDbContext>(options =>
                    {
                        // Configuração da conexão com o banco de dados PostgreSQL
                        options.UseNpgsql("Host=localhost;Port=5432;Database=Transacoes;Username=postgres;Password=123456;");
                    });

                    });

                    webBuilder.Configure(app =>
                    {
                         app.UseRouting();
                         app.UseAuthentication();
                         app.UseAuthorization();
                         app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
                    });
                });


                
                }

            
        
    }

