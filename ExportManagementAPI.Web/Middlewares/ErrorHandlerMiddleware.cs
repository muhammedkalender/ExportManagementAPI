using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using ExportManagementAPI.Domain.Entities.API;
using ExportManagementAPI.Domain.Entities.Bases;
using ExportManagementAPI.Domain.Exceptions;
using Microsoft.AspNetCore.Http;

namespace ExportManagementAPI.Web.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                object responseModel = null;

                switch (error)
                {
                    case ApiException e:
                        // custom application error
                        responseModel = new ResponseBadRequestEntity();

                        response.StatusCode = (int) HttpStatusCode.BadRequest;
                        break;
                    case ValidationException e:
                        // custom application error
                        responseModel = new ResponseUnprocessableEntity();

                        ((ResponseUnprocessableEntity) responseModel).Errors = e.Errors;

                        response.StatusCode = (int) HttpStatusCode.UnprocessableEntity;
                        break;
                    case KeyNotFoundException e:
                        // not found error
                        responseModel = new ResponseNotFoundEntity();

                        response.StatusCode = (int) HttpStatusCode.NotFound;
                        break;

                    case RowNotInTableException e:
                        //not implemented error
                        responseModel = new ResponseNotImplementedEntity();

                        response.StatusCode = (int) HttpStatusCode.NotImplemented;
                        break;
                    default:
                        // unhandled error
                        responseModel = new ResponseInternalServerErrorEntity();

                        response.StatusCode = (int) HttpStatusCode.InternalServerError;
                        break;
                }

                ((ResponseBase) responseModel).IsSuccess = false;
                ((ResponseBase) responseModel).Message = error?.Message;

                var result = JsonSerializer.Serialize(responseModel);

                await response.WriteAsync(result);
            }
        }
    }
}