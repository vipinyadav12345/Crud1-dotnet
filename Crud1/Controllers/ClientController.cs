using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crud1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
       /* private static List<Client> clients = new List<Client>
            {
                new Client {
                    Id = 1 ,
                    Name = "Vpn",
                    FirstName ="vipin",
                    LastName = "Yadav" ,
                    Place = "new city "
                },
                new Client {
                      Id = 2,
                     Name = "tony",
                        FirstName = "yark",
                         LastName = "stret",
                           Place =  "new"
                },
                new Client {
                      Id = 3,
                     Name = "njh",
                        FirstName = "ubu",
                         LastName = "stret",
                           Place =  "1542"
                }
            };*/
        
        private readonly DataContext _context;

        public ClientController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Client>>> Get()
        {
            return Ok(await _context.Clientss.ToListAsync());
            // return Ok(clients);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> Get(int id)
        {
            // var client = clients.Find(h => h.Id == id);
            var client = await _context.Clientss.FindAsync(id);
            if (client == null)
                return BadRequest("Hero not Found.");  
            return Ok(client);
        }
        [HttpPost]
        public async Task<ActionResult<List<Client>>> AddClient(Client client)
        {
            _context.Clientss.Add(client);
            await _context.SaveChangesAsync();
            return Ok(await _context.Clientss.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<Client>>> UpdateClient(Client request)
        {
            var dbclient = await _context.Clientss.FindAsync(request.Id);
            if (dbclient == null)
                return BadRequest("Hero not Found.");
       

           dbclient.Name = request.Name;
            dbclient.FirstName = request.FirstName;
            dbclient.LastName = request.LastName;
            dbclient.Place = request.Place;
            await _context.SaveChangesAsync();
            return Ok(await _context.Clientss.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Client>>> Delete(int id)
        {
            var dbclient = await _context.Clientss.FindAsync(id);
            if (dbclient == null)
                return BadRequest("Hero not Found.");
          _context.Clientss.Remove(dbclient);
            await _context.SaveChangesAsync();
            return Ok(await _context.Clientss.ToListAsync());

           
        }

    }
}
