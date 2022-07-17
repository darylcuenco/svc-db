using svc_db.Interfaces;
using svc_db.Models;
using svc_db.Utils;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Couchbase;

namespace svc_db.Implementations{
    public class OperationsImplementation : IOperations{
        
        private readonly ILogger<OperationsImplementation> _logger;
        
        private readonly Dictionary<String, String> config = new Dictionary<String, String>();
        private Guid uuid;
        public OperationsImplementation(ILogger<OperationsImplementation> logger)
        {   
            initCreds();
            _logger = logger;
        }

        private void initCreds(){
            config.Add("username","Administrator");
            config.Add("password","password");
            config.Add("bucket","training-bucket");
        }
        public GenericResponse upsert(dynamic req){
            GenericResponse resp = new GenericResponse();

            // var cluster = await Cluster.ConnectAsync(
            //     "couchbase://cb:8091",
            //     config["username"],
            //     config["password"]);

            // var bucket = await cluster.BucketAsync(config["bucket"]);
            // var collection = await bucket.DefaultCollection();

             uuid = Guid.NewGuid();
            // var upsertResult = await collection.UpsertAsync(uuid.ToString(), new { Name = "Ted", Age = 31 });
            // await cluster.DisposeAsync();

            //upsert implementation
            resp.data = uuid.ToString();
            resp.message = "";//upsertResult;
            return resp;

        }
        public ResponseModel <List<ClientModel>> search(dynamic req){
            
            var jsonObj = JsonConvert.DeserializeObject<ClientModel>(req.ToString());
            Console.WriteLine("req: " + jsonObj.id);
            ResponseFactory<ClientModel> responseFactory = new ResponseFactory<ClientModel>();
            bool isSuccess = true;

            List<ClientModel> list = new List<ClientModel>();
            ClientModel cm = new ClientModel();
            cm.id = "1";
            cm.fname = "a";
            cm.mname = "b";
            cm.lname = "c";
            list.Add(cm);
            // string combinedString = string.Join( ",", list);


            return responseFactory.CreateResponseModelList(isSuccess,"search", list);

        }
        public GenericResponse delete(dynamic req){
            GenericResponse resp = new GenericResponse();
            //delete implementation
            resp.data = req;
            resp.message = "delete implementation";
            return resp;
        }

    }
}