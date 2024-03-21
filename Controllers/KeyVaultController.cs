using Microsoft.AspNetCore.Mvc;

namespace secretAssignment.Controllers
{
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
    }
}
