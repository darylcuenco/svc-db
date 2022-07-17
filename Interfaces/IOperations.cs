using svc_db.Models;

namespace svc_db.Interfaces{
    public interface IOperations{

        GenericResponse upsert(dynamic req);
        ResponseModel <List<ClientModel>> search(dynamic req);
        GenericResponse delete(dynamic req);

    }
}