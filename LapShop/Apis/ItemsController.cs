using LapShop.Domains;
using LapShop.Domains.ViewModels;
using LapShop.Services.Item;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LapShop.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ILogger<ItemsController> _logger;
        private readonly IItemService _itemService;

        public ItemsController(ILogger<ItemsController>  logger, IItemService itemService)
        {
            _logger = logger;
            _itemService = itemService;
        }

        // GET: api/<ItemsController>
        [HttpGet]
        public List<VwItemsVM> Get()
        {
            var data = _itemService.PrepareDashboard(null);
            return data.ToList();
        }

        // GET api/<ItemsController>/5
        [HttpGet("{id}")]
        public VwItemsVM Get(int id)
        {
            return _itemService.GetSingle(id);
        }

        // POST api/<ItemsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] VwItemsVM item)
        {
            try
            {
                await _itemService.Save(item);
                return Ok("Item saved successfully.");
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex, "An error occurred while saving the item.");
                return StatusCode(500, "A server side error occurred while processing your request: " + ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while saving the item.");
                return StatusCode(500, "A  server side error occurred while processing your request: " + ex.Message);
            }
        }

        // DELETE api/<ItemsController>/Delete/5
        [HttpPost("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _itemService.Delete(id);
                return Ok("Deletion successful");
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the item.");
                return StatusCode(500, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the item.");
                return StatusCode(500, "A server side error occurred while processing your request: " + ex.Message);
            }
        }
    }
}
