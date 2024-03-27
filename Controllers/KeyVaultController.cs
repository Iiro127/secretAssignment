using Microsoft.AspNetCore.Mvc;

namespace secretAssignment.Controllers
{
    /*
        "tenantId": "36c8d6bc-e998-4190-a69f-c13424063463",
        subscription id: 675c80f2-986e-4458-b5f3-88bc366df5a9
        client id: 83ba5f09-0c1f-4f16-bb43-8e1918b0898b
        
    */
    [Route("api/[controller]")]
    [ApiController]
    public class KeyVaultController : ControllerBase
    {
        private readonly ILogger<KeyVaultController> _logger;
        private readonly IConfiguration _configuration;
        private readonly Services.IKeyVaultSecretManager _keyVaultSecretManager;

        public KeyVaultController(ILogger<KeyVaultController> logger, IConfiguration configuration, Services.IKeyVaultSecretManager keyVaultSecretManager)
        {
            _logger = logger;
            _configuration = configuration;
            _keyVaultSecretManager = keyVaultSecretManager;
        }

        [HttpGet("Open")]
        public IActionResult Get()
        {
            return Ok("Terve");
        }

        [HttpGet("GetKeyVaultSecrets")]
        public async Task<IActionResult> GetKeyVaultSecret(string secret)
        {
            var response = await _keyVaultSecretManager.GetSecretAsync(secret);
            return Ok(response);
        }

        [HttpGet("GetSecretConfigKey")]
        public async Task<IActionResult> GetKeyVaultSecretConfig(string secret)
        {
            var response = _configuration[secret];
            return Ok(response);
        }
    }
}
