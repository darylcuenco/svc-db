using svc_db.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;

namespace svc_db.Utils
{
    public class ResponseFactory<T>
    {
        public ResponseModel<T> successResponse(T data, string message, bool isSuccess)
        {
            
            ResponseModel<T> resp = new ResponseModel<T>();
            resp.statusCode = 0;
            resp.status = "Ok";
            resp.errorCode = 0;
            resp.message = message;
            resp.data = data;
            return resp;
            
        }

        ///<summary>
        ///Create ResponseModel with list of data
        ///</summary>
        public ResponseModel<List<T>> CreateResponseModelList(bool isSuccess, string action, List<T> responseData, string? successMessage = null, string? failMessage = null)
        {
            ResponseModel<List<T>> resp = new ResponseModel<List<T>>();
            if (isSuccess)
                resp.data = responseData;

            resp.success = isSuccess;
            resp.message = isSuccess ? successMessage ?? "Success" : failMessage ?? "Failed";
            resp.statusCode = GetStatusCode(isSuccess, action);
            resp.status = GetStatusCodeDescription(resp.statusCode);
            return resp;
        }

        ///<summary>
        ///Method for getting http status code
        ///</summary>
        public int GetStatusCode(bool isSuccess, string action)
        {
            if (isSuccess)
            {
                if (action.Equals("add") || action.Equals("insert"))
                    return (int)HttpStatusCode.Created;
                else
                    return (int)HttpStatusCode.OK;
            }
            else
                return (int)HttpStatusCode.InternalServerError;
        }

        ///<summary>
        ///Method for getting http status code description
        ///</summary>
        public string GetStatusCodeDescription(int? statusCode)
        {
            if (statusCode == (int)HttpStatusCode.Created)
                return "Created";
            if (statusCode == (int)HttpStatusCode.OK)
                return "OK";
            if (statusCode == (int)HttpStatusCode.InternalServerError)
                return "Internal Server Error";
            return "";
        }

    }

}