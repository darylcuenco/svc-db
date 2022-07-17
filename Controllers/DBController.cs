using Microsoft.AspNetCore.Mvc;
using svc_db.Models;
using svc_db.Interfaces;
using Newtonsoft.Json;

namespace svc_db.Controllers;

[ApiController]
[Route("[controller]")]
public class DBController : ControllerBase
{
    
    private readonly ILogger<DBController> _logger;
    private readonly IOperations _op;

    public DBController(ILogger<DBController> logger, IOperations op)
    {

        _op = op;
        _logger = logger;
    }

    [HttpGet("health")]
    public string health()
    {
        return "Status: OK";
    }

    [HttpPost("upsert")]
    public GenericResponse upsert(dynamic req){
        return _op.upsert(req);
    }
    
    [HttpPost("search")]
    public ResponseModel<List<ClientModel>> search (dynamic req){
        return _op.search(req);
    }

    [HttpPost("delete")]
    public GenericResponse delete(dynamic req){
        return _op.delete(req);
    }
}
